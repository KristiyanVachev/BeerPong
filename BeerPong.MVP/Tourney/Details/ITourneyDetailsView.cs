using System;
using WebFormsMvp;

namespace BeerPong.MVP.Tourney.Details
{
    public interface ITourneyDetailsView : IView<TourneyDetailsViewModel>
    {
        event EventHandler<TourneyDetailsEventArgs> MyTourneyDetails;

        event EventHandler<JoinTourneyEventArgs> JoinTourney;
    }
}
