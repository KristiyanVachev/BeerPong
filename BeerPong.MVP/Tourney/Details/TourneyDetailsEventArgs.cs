using System;

namespace BeerPong.MVP.Tourney.Details
{
    public class TourneyDetailsEventArgs : EventArgs
    {
        public TourneyDetailsEventArgs(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
