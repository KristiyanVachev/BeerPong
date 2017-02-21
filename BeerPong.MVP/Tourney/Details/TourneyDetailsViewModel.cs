using System.Collections.Generic;
using BeerPong.Models;

namespace BeerPong.MVP.Tourney.Details
{
    public class TourneyDetailsViewModel
    {

        public TourneyDetailsViewModel()
        {

        }

        public TourneyDetailsViewModel(int id, string name, bool hasJoined, ICollection<string> players)
        {
            this.Id = id;
            this.Name = name;
            this.HasJoined = hasJoined;
            this.Players = players;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool HasJoined { get; set; }

        public ICollection<string> Players { get; set; }
    }
}
