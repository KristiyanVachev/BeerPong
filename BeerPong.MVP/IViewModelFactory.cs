using System.Collections.Generic;
using BeerPong.MVP.Tourney.Details;

namespace BeerPong.MVP
{
    public interface IViewModelFactory
    {
        TourneyDetailsViewModel CreateTourneyDetailsViewModel(int id, string name, string status);

        TourneyDetailsViewModel CreateTourneyDetailsViewModel(int id, string name, bool hasJoined, ICollection<string> players, bool isOwner, string status);
    }
}
