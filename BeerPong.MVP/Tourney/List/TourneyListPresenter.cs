using System;
using System.Collections.Generic;
using System.Linq;
using BeerPong.MVP.Tourney.Details;
using BeerPong.Services.Contracts;
using WebFormsMvp;

namespace BeerPong.MVP.Tourney.List
{
    public class TourneyListPresenter : Presenter<ITourneyListView>
    {
        private readonly ITourneyService service;
        private readonly IViewModelFactory factory;

        public TourneyListPresenter(ITourneyListView view, ITourneyService service, IViewModelFactory factory)
            : base(view)
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

            this.View.MyInit += View_MyInit;
        }


        private void View_MyInit(object sender, TourneyListEventArgs e)
        {
            IEnumerable<TourneyDetailsViewModel> tourneys = this.service.GetTourneys()
                .Select(x => this.factory.CreateTourneyDetailsViewModel(x.Id, x.Name, x.Status));

            this.View.Model.Products = tourneys;
        }
    }
}
