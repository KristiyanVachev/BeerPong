using System;
using System.Web;

namespace BeerPong.MVP.Tourney.Details
{
    public class TourneyDetailsEventArgs : EventArgs
    {
        public TourneyDetailsEventArgs(int id, HttpContext context)
        {
            this.Id = id;
            this.Context = context;
        }

        public int Id { get; set; }

        public HttpContext Context { get; set; }

    }
}
