using System;

namespace BeerPong.MVP.Tourney.Details
{
    public class EndTourneyEventArgs : EventArgs
    {
        public EndTourneyEventArgs(int tourneyId, string winnerName)
        {
            this.TourneyId = tourneyId;
            this.WinnerName = winnerName;
        }

        public int TourneyId { get; set; }

        public string WinnerName { get; set; }
    }
}
