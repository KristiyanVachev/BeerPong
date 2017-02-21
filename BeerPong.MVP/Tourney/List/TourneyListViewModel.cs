using System.Collections.Generic;
using BeerPong.MVP.Tourney.Details;

namespace BeerPong.MVP.Tourney.List
{
    public class TourneyListViewModel
    {
        public IEnumerable<TourneyDetailsViewModel> Products { get; set; }
    }
}
