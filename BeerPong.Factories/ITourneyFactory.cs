using BeerPong.Models;

namespace BeerPong.Factories
{
    public interface ITourneyFactory
    {
        Tourney CreateTourney(string name);

        //TODO Move
        Player CreatePlayer(Tourney tourney, User user, string name);
    }
}
