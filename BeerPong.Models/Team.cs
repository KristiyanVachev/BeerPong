using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerPong.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Player PlayerOne { get; set; }

        public Player PlayerTwo { get; set; }

        public int GameId { get; set; }

        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }
    }
}
