using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerPong.Models
{
    public class Team
    {
        private ICollection<Game> games;

        public Team()
        {
            this.games = new HashSet<Game>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Player PlayerOne { get; set; }

        public Player PlayerTwo { get; set; }

        public int TourneyId { get; set; }

        [ForeignKey("TourneyId")]
        public virtual Tourney Tourney { get; set; }

        public virtual ICollection<Game> Games
        {
            get { return this.games; }
            set { this.games = value; }
        }
    }
}
