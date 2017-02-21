using System;
using System.Linq;
using BeerPong.Services.Contracts;
using Bytes2you.Validation;
using WebFormsMvp;

namespace BeerPong.MVP.Administration.Tourneys
{
    public class TourneyPresenter : Presenter<ITourneyView>
    {
        private readonly ITourneyService service;
        private readonly IViewModelFactory factory;

        public TourneyPresenter(ITourneyView view, ITourneyService service, IViewModelFactory factory)
            : base(view)
        {
            Guard.WhenArgument(service, "Service").IsNull().Throw();
            Guard.WhenArgument(factory, "Factory").IsNull().Throw();

            this.service = service;
            this.factory = factory;

            this.View.MyInit += View_MyInit;
            this.View.EditTourney += View_EditTourney;
            this.View.DeleteTourney += View_DeleteTourney;
        }

        private void View_DeleteTourney(object sender, DeleteTourneyEventArgs e)
        {
            var id = e.Id;

            this.service.DeleteTourney(id);
        }

        private void View_EditTourney(object sender, EditTourneyEventArgs e)
        {
            var product = this.service.GetById(e.Model.Id);

            if (product != null)
            {
                product = this.SetupChanges(product, e);

                this.service.EditTourney(product);
            }
        }

        private Models.Tourney SetupChanges(Models.Tourney tourney, EditTourneyEventArgs args)
        {
            tourney.Name = args.Model.Name;
            tourney.Status = args.Model.Status;

            return tourney;
        }


        private void View_MyInit(object sender, EventArgs e)
        {
            var tourneys = this.service.GetTourneys();

            this.View.Model.Tourneys = tourneys
                .Select(x => 
                this.factory.CreateTourneyDetailsViewModel(x.Id, x.Name, x.Status));
        }
    }
}
