using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BeerPong.Models.Contracts;

namespace BeerPong.Models
{
    public class Tourney : ITourney
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
            this.Status = "Open";
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        //TOOD: Extract do enum = Open, Active, Closed
        public string Status { get; set; }

        [ForeignKey("Winner")]
        public string WinnerId { get; set; }

        [ForeignKey("Id")]
        public virtual User Winner { get; set; }

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
