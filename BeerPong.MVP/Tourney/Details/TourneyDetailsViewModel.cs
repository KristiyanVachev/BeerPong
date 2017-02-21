using System.Collections.Generic;
using BeerPong.Models;

namespace BeerPong.MVP.Tourney.Details
{
    public class TourneyDetailsViewModel
    {

        public TourneyDetailsViewModel()
        {

        }

        public TourneyDetailsViewModel(int id, string name, bool hasJoined, ICollection<string> players, bool isOwner, string status)
        {
            this.Id = id;
            this.Name = name;
            this.HasJoined = hasJoined;
            this.Players = players;
            this.IsOwner = isOwner;
            this.Status = status;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool HasJoined { get; set; }

        public ICollection<string> Players { get; set; }

        public bool IsOwner { get; set; }

        public string Status { get; set; }
    }
}
