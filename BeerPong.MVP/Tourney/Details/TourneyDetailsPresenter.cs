using System;
using BeerPong.Services.Contracts;
using WebFormsMvp;

namespace BeerPong.MVP.Tourney.Details
{
    public class TourneyDetailsPresenter : Presenter<ITourneyDetailsView>
    {
        private ITourneyService service;
        private IViewModelFactory factory;

        public TourneyDetailsPresenter(ITourneyDetailsView view, ITourneyService service, IViewModelFactory factory) : base(view)
        {
            this.Service = service;
            this.Factory = factory;

            this.View.MyTourneyDetails += View_MyProductDetails;
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
    }
}
