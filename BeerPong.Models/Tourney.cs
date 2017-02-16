using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeerPong.Models
{
    public class Tourney
    {
        private ICollection<User> users;
        private ICollection<Team> teams;
        private ICollection<Game> games;

        public Tourney()
        {
            this.users = new HashSet<User>();
            this.teams = new HashSet<Team>();
            this.games = new HashSet<Game>();
        }

        [Key]
        public int Id { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
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
