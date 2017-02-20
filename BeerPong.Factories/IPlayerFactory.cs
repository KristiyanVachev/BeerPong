using BeerPong.Models;

namespace BeerPong.Factories
{
    public interface IPlayerFactory
    {
        Player CreatePlayer(Tourney tourney, User user);
    }
}
