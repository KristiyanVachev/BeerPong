using System;
using System.Web;

namespace BeerPong.MVP.Tourney.Details
{
    public class JoinTourneyEventArgs : EventArgs
    {
        public JoinTourneyEventArgs(bool isJoined, int tourneyId, HttpContext context)
        {
            this.IsJoined = isJoined;
            this.TourneyId = tourneyId;
            this.Context = context;
        }

        public bool IsJoined { get; set; }

        public int TourneyId { get; set; }

        public HttpContext Context { get; set; }
    }
}
