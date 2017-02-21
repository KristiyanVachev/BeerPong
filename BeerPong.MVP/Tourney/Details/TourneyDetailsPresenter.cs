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
        private ITourneyService service;
        private IViewModelFactory factory;
        //private IJoinTourneyService joinTourneyService;

        public TourneyDetailsPresenter(ITourneyDetailsView view, ITourneyService service, IViewModelFactory factory) : base(view)
        {
            this.Service = service;
            this.Factory = factory;

            this.View.MyTourneyDetails += View_MyProductDetails;
            this.View.JoinTourney += View_MyJoinTourney;
        }

        public ITourneyService Service
        {
            get { return this.service; }
            set
            {
                Guard.WhenArgument(value, "service").IsNull();
                this.service = value;
            }
        }

        public IViewModelFactory Factory
        {
            get { return this.factory; }
            set
            {
                Guard.WhenArgument(value, "factory").IsNull();
                this.factory = value;
            }
        }

        public void View_MyProductDetails(object sender, TourneyDetailsEventArgs e)
        {
            var tourneyId = e.Id;
            var userId = e.Context.User.Identity.GetUserId();

            var tourney = this.Service.GetById(tourneyId);

            var playerHasJoined = this.Service.UserHasJoined(tourneyId, userId);
            var userIsOwner = this.service.UserIsOwner(tourneyId, userId);

            List<string> playerNames = new List<string>();
            foreach (var tourneyPlayer in tourney.Players)
            {
                playerNames.Add(tourneyPlayer.Name);
            }

            var viewModel = this.Factory.CreateTourneyDetailsViewModel(tourney.Id, tourney.Name, playerHasJoined, playerNames, userIsOwner);

            this.View.Model = viewModel;
        }

        public void View_MyJoinTourney(object sender, JoinTourneyEventArgs e)
        {
            //TODO don't join if player has already joined
            var userId = e.Context.User.Identity.GetUserId();
            var tourneyId = e.TourneyId;

            if (!e.IsJoined)
            {
                this.Service.JoinTourney(tourneyId, userId);
                this.View.Model.HasJoined = true;
            }
            else
            {
                this.service.LeaveTourney(tourneyId, userId);
                this.View.Model.HasJoined = false;
            }
        }
    }
}
