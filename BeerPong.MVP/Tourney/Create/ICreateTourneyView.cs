using System;
using WebFormsMvp;

namespace BeerPong.MVP.Tourney.Create
{
    public interface ICreateTourneyView : IView<CreateTourneyViewModel>
    {
        event EventHandler<CreateTourneyEventArgs> MyCreateTourney;
    }
}
