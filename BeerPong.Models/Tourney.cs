using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeerPong.Models
{
    public class Tourney
    {
        private ICollection<Player> players;
        private ICollection<Team> teams;
        private ICollection<Game> games;

        public Tourney()
        {
            this.players = new HashSet<Player>();
            this.teams = new HashSet<Team>();
            this.games = new HashSet<Game>();
        }

        public Tourney(string name)
            : this()
        {
            this.Name = name;
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Player> Players
        {
            get { return this.players; }
            set { this.players = value; }
        }

        public virtual ICollection<Team> Teams
        {
            get { return this.teams; }
            set { this.teams = value; }
        }

        public virtual ICollection<Game> Games
        {
            get { return this.games; }
            set { this.games = value; }
        }
    }
}
