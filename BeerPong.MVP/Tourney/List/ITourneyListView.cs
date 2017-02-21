using System;
using WebFormsMvp;

namespace BeerPong.MVP.Tourney.List
{
    public interface ITourneyListView : IView<TourneyListViewModel>
    {
        event EventHandler<TourneyListEventArgs> MyInit;
    }
}
