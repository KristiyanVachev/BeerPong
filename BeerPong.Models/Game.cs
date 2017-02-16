using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeerPong.Models
{
    public class Game
    {
        private ICollection<Team> teams;

        public Game()
        {
            this.teams = new HashSet<Team>();
        }

        [Key]
        public int Id { get; set; }
      
        public virtual ICollection<Team> Teams
        {
            get { return this.teams; }
            set { this.teams = value; }
        }
    }
}
