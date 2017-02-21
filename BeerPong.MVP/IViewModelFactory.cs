using System.Collections.Generic;
using BeerPong.Models;
using BeerPong.MVP.Tourney.Details;

namespace BeerPong.MVP
{
    public interface IViewModelFactory
    {
        TourneyDetailsViewModel CreateTourneyDetailsViewModel(int id, string name, bool hasJoined, ICollection<string> players);
    }
}
