using System;
using System.Collections.Generic;
using System.Linq;
using BeerPong.Services.Contracts;
using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using WebFormsMvp;

namespace BeerPong.MVP.Tourney.Details
{
    public class TourneyDetailsPresenter : Presenter<ITourneyDetailsView>
    {
        private readonly ITourneyService service;
        private readonly IViewModelFactory factory;
        //private IJoinTourneyService joinTourneyService;

        public TourneyDetailsPresenter(ITourneyDetailsView view, ITourneyService service, IViewModelFactory factory) : base(view)
        {
            Guard.WhenArgument(service, "service").IsNull();
            Guard.WhenArgument(factory, "factory").IsNull();

            this.service = service;
            this.factory = factory;

            this.View.MyTourneyDetails += View_MyProductDetails;
            this.View.JoinTourney += View_MyJoinTourney;
            this.View.MyEndTourney += View_MyEndTourney;
        }

        public void View_MyProductDetails(object sender, TourneyDetailsEventArgs e)
        {
            var tourneyId = e.Id;
            var userId = e.Context.User.Identity.GetUserId();

            var tourney = this.service.GetById(tourneyId);

            var playerHasJoined = this.service.UserHasJoined(tourneyId, userId);
            var userIsOwner = this.service.UserIsOwner(tourneyId, userId);

            List<string> playerNames = new List<string>();
            foreach (var tourneyPlayer in tourney.Players)
            {
                playerNames.Add(tourneyPlayer.Name);
            }

            var viewModel = this.factory.CreateTourneyDetailsViewModel(tourney.Id, tourney.Name, playerHasJoined, playerNames, userIsOwner, tourney.Status);

            this.View.Model = viewModel;
        }

        public void View_MyJoinTourney(object sender, JoinTourneyEventArgs e)
        {
            //TODO don't join if player has already joined
            var userId = e.Context.User.Identity.GetUserId();
            var tourneyId = e.TourneyId;

            if (!e.IsJoined)
            {
                this.service.JoinTourney(tourneyId, userId);
                this.View.Model.HasJoined = true;
            }
            else
            {
                this.service.LeaveTourney(tourneyId, userId);
                this.View.Model.HasJoined = false;
            }
        }

        public void View_MyEndTourney(object sender, EndTourneyEventArgs e)
        {
            this.service.EndTourney(e.TourneyId, e.WinnerName);
        }
    }
}
