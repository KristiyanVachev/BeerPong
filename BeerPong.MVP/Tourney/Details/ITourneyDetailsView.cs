using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace BeerPong.MVP.Tourney.Details
{
    public interface ITourneyDetailsView : IView<TourneyDetailsViewModel>
    {
        event EventHandler<TourneyDetailsEventArgs> MyTourneyDetails;
    }
}
