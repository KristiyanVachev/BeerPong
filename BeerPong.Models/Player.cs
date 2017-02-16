using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerPong.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        //public int UserId { get; set; }

        //[ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
