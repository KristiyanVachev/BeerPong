using System.Collections.Generic;

namespace BeerPong.Models.Contracts
{
    public interface ITourney
    {           
        int Id { get; set; }

        string Name { get; set; }

        string Status { get; set; }

        string WinnerId { get; set; }

        User Winner { get; set; }

        ICollection<Player> Players { get; set; }

        ICollection<Team> Teams { get; set; }

        ICollection<Game> Games { get; set; }
    }
}
