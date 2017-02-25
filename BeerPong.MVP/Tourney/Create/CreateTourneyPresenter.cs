using System;
using BeerPong.Services.Contracts;
using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using WebFormsMvp;

namespace BeerPong.MVP.Tourney.Create
{
    public class CreateTourneyPresenter : Presenter<ICreateTourneyView>
    {
        private readonly ITourneyService service;

        public CreateTourneyPresenter(ICreateTourneyView view, ITourneyService service) : base(view)
        {
            this.service = service;

            this.View.MyCreateTourney += OnCreateTourney;
        }
        
        public void OnCreateTourney(object sender, CreateTourneyEventArgs e)
        {
            var userId = e.Context.User.Identity.GetUserId();

            var tourney = this.service.CreateTourney(e.Name, userId);
            this.View.Model.Id = tourney.Id;
        }
    }
}
