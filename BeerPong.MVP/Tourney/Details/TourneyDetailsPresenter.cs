using System;
using BeerPong.Services.Contracts;
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
                if (value == null)
                {
                    throw new ArgumentNullException("Service cannot be null");
                }

                this.service = value;
            }
        }

        public IViewModelFactory Factory
        {
            get { return this.factory; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Factory cannot be null");
                }

                this.factory = value;
            }
        }

        public void View_MyProductDetails(object sender, TourneyDetailsEventArgs e)
        {
            var id = e.Id;

            var tourney = this.Service.GetById(id);

            var viewModel = this.Factory.CreateTourneyDetailsViewModel(tourney.Id, tourney.Name);

            this.View.Model = viewModel;
        }

        public void View_MyJoinTourney(object sender, JoinTourneyEventArgs e)
        {
            var userId = e.Context.User.Identity.GetUserId();

            var tourneyId = e.TourneyId;

            this.Service.JoinTourney(tourneyId, userId);
        }
    }
}
