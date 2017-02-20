using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerPong.Models
{
    public class Player
    {
        public Player()
        {
            
        }

        public Player(Tourney tourney, User user)
        {
            //TODO Guard
            this.Tourney = tourney;
            this.User = user;
        }

        [Key]
        public int PlayerId { get; set; }

        public string UserId { get; set; }

        public int TourneyId { get; set; }

        //[ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("TourneyId")]
        public virtual Tourney Tourney { get; set; }
    }
}
