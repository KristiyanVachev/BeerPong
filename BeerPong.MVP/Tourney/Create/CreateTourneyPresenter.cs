using System;
using BeerPong.Services.Contracts;
using WebFormsMvp;

namespace BeerPong.MVP.Tourney.Create
{
    public class CreateTourneyPresenter : Presenter<ICreateTourneyView>
    {
        //TODO propperty
        private readonly ITourneyService service;

        public CreateTourneyPresenter(ICreateTourneyView view, ITourneyService service) : base(view)
        {
            if (service == null)
            {
                throw new ArgumentNullException("Service cannot be null");
            }

            this.service = service;

            this.View.MyCreateTourney += OnCreateTourney;

        }
        public void OnCreateTourney(object sender, CreateTourneyEventArgs e)
        {
            var tourney = this.service.CreateTourney(e.Name);
            this.View.Model.Id = tourney.Id;
        }
    }
}
