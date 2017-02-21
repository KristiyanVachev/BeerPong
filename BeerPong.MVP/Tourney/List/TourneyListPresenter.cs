using System;
using System.Collections.Generic;
using System.Linq;
using BeerPong.MVP.Tourney.Details;
using BeerPong.Services.Contracts;
using Bytes2you.Validation;
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
            Guard.WhenArgument(service, "Service").IsNull().Throw();
            Guard.WhenArgument(factory, "Factory").IsNull().Throw();

            this.service = service;
            this.factory = factory;

            this.View.MyInit += View_MyInit;
        }

        private void View_MyInit(object sender, TourneyListEventArgs e)
        {
            IEnumerable<TourneyDetailsViewModel> tourneys = this.service.GetTourneys()
                .Select(x => this.factory.CreateTourneyDetailsViewModel(x.Id, x.Name, x.Status));

            this.View.Model.Tourneys = tourneys;
        }
    }
}
