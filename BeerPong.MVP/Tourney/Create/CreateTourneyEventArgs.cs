using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerPong.MVP.Tourney.Create
{
    public class CreateTourneyEventArgs : EventArgs
    {
        public CreateTourneyEventArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
