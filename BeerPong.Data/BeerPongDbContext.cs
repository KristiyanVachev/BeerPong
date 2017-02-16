using System.Data.Entity;
using BeerPong.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BeerPong.Data
{
    public class BeerPongDbContext : IdentityDbContext<User>
    {
        public BeerPongDbContext(): base("BeerPongDb")
        {

        }

        public static BeerPongDbContext Create()
        {
            return new BeerPongDbContext();
        }

        public virtual IDbSet<Player> Players { get; set; }

        public virtual IDbSet<Team> Teams { get; set; }

        public virtual IDbSet<Game> Games { get; set; }

        public virtual IDbSet<Tourney> Tourneys { get; set; }
    }
}
