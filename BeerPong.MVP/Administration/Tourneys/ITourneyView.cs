using System;
using BeerPong.MVP.Tourney.List;
using WebFormsMvp;

namespace BeerPong.MVP.Administration.Tourneys
{
     public interface ITourneyView : IView<TourneyListViewModel>
    {
        event EventHandler MyInit;

        event EventHandler<EditTourneyEventArgs> EditTourney;

        event EventHandler<DeleteTourneyEventArgs> DeleteTourney;
    }
}
