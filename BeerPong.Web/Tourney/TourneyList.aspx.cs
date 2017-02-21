using System;
using System.Collections.Generic;
using BeerPong.MVP.Tourney.Details;
using BeerPong.MVP.Tourney.List;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace BeerPong.Web.Tourney
{
    [PresenterBinding(typeof(TourneyListPresenter))]
    public partial class TourneyList : MvpPage<TourneyListViewModel>, ITourneyListView
    {
        public event EventHandler<TourneyListEventArgs> MyInit;

        protected void Page_Load(object sender, EventArgs e)
        {
            var args = new TourneyListEventArgs();
            this.MyInit?.Invoke(this, args);
        }

        public IEnumerable<TourneyDetailsViewModel> Select()
        {
            return this.Model.Tourneys;
        }
    }
}