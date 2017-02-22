using BeerPong.Models;

namespace BeerPong.Factories
{
    public interface IFactory
    {
        Tourney CreateTourney(string name, User owner);

        Player CreatePlayer(Tourney tourney, User user, string name);
    }
}
