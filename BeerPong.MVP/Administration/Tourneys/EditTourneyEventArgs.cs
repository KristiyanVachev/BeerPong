using System;
using BeerPong.MVP.Tourney.Details;

namespace BeerPong.MVP.Administration.Tourneys
{
   public class EditTourneyEventArgs : EventArgs
    {

        public EditTourneyEventArgs(TourneyDetailsViewModel model)
        {
            this.Model = model;
        }

        public TourneyDetailsViewModel Model { get; set; }
    }
}
