using System;
using BeerPong.Services.Contracts;
using WebFormsMvp;

namespace BeerPong.MVP.Tourney.Details
{
    public class TourneyDetailsPresenter : Presenter<ITourneyDetailsView>
    {
        private readonly ITourneyService service;
        private readonly IViewModelFactory factory;

        public TourneyDetailsPresenter(ITourneyDetailsView view, ITourneyService service, IViewModelFactory factory) : base(view)
        {
            if (service == null)
            {
                throw new ArgumentNullException("service cannot be null");
            }

            if (factory == null)
            {
                throw new ArgumentNullException("factory cannot be null");
            }

            this.service = service;
            this.factory = factory;

            this.View.MyTourneyDetails += View_MyProductDetails;
        }

        public void View_MyProductDetails(object sender, TourneyDetailsEventArgs e)
        {
            var id = e.Id;

            var tourney = this.service.GetById(id);

            var viewModel = this.factory.CreateTourneyDetailsViewModel(tourney.Id, tourney.Name);

            this.View.Model = viewModel;
        }
    }
}
