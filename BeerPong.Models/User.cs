using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BeerPong.Models
{
    public class User : IdentityUser
    {
        //private ICollection<Tourney> tourneys;

        //public User()
        //{
        //    this.tourneys = new HashSet<Tourney>();
        //}

        public string Name { get; set; }

        public int TourneysWon { get; set; }

        public int TotalGames { get; set; }

        public int GamesWon { get; set; }

        //public virtual ICollection<Tourney> Tourneys
        //{
        //    get { return this.tourneys; }
        //    set { this.tourneys = value; }
        //}

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}
