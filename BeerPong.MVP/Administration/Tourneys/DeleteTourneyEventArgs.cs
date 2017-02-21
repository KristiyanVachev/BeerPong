using System;

namespace BeerPong.MVP.Administration.Tourneys
{
    public class DeleteTourneyEventArgs : EventArgs
    {
        public DeleteTourneyEventArgs(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
