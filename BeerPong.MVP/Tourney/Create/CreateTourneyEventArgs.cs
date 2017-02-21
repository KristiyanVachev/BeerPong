using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BeerPong.MVP.Tourney.Create
{
    public class CreateTourneyEventArgs : EventArgs
    {
        public CreateTourneyEventArgs(string name, HttpContext context)
        {
            this.Name = name;
            this.Context = context;
        }

        public string Name { get; set; }

        public HttpContext Context { get; set; }

    }
}
