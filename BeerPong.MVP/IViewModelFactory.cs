using BeerPong.MVP.Tourney.Details;

namespace BeerPong.MVP
{
    public interface IViewModelFactory
    {
        TourneyDetailsViewModel CreateTourneyDetailsViewModel(int id, string name);
    }
}
