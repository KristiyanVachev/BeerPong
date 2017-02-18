using System;
using BeerPong.Services.Contracts;
using WebFormsMvp;

namespace BeerPong.MVP.Tourney.Create
{
    public class CreateTourneyPresenter : Presenter<ICreateTourneyView>
    {
        private ITourneyService service;

        public CreateTourneyPresenter(ICreateTourneyView view, ITourneyService service) : base(view)
        {
            this.service = service;

            this.View.MyCreateTourney += OnCreateTourney;
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
        public void OnCreateTourney(object sender, CreateTourneyEventArgs e)
        {
            var tourney = this.service.CreateTourney(e.Name);
            this.View.Model.Id = tourney.Id;
        }
    }
}
