using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerPong.Models;

namespace BeerPong.Data
{
    public class BeerPongDbContext : DbContext
    {
        public BeerPongDbContext()
        {

        }

        public virtual IDbSet<Player> Players { get; set; }

        public virtual IDbSet<Team> Teams { get; set; }

        public virtual IDbSet<Game> Games { get; set; }
    }
}
