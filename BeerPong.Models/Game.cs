using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerPong.Models
{
    public class Game
    {
        private ICollection<Team> teams;

        public Game()
        {
            this.teams = new HashSet<Team>();
        }

        public int Id { get; set; }
      
        public virtual ICollection<Team> Teams
        {
            get { return this.teams; }
            set { this.teams = value; }
        }
    }
}
