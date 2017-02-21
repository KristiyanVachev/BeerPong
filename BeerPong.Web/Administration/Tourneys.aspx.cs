using System;
using System.Collections.Generic;
using System.Linq;
using BeerPong.MVP.Administration.Tourneys;
using BeerPong.MVP.Tourney.Details;
using BeerPong.MVP.Tourney.List;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace BeerPong.Web.Administration
{
    [PresenterBinding(typeof(TourneyPresenter))]
    public partial class Tourneys : MvpPage<TourneyListViewModel>, ITourneyView
    {
        public event EventHandler MyInit;
        public event EventHandler<EditTourneyEventArgs> EditTourney;
        public event EventHandler<DeleteTourneyEventArgs> DeleteTourney;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.MyInit?.Invoke(sender, e);
        }

        public void Delete(int id)
        {
            var args = new DeleteTourneyEventArgs(id);

            this.DeleteTourney?.Invoke(this, args);
        }

        public IEnumerable<TourneyDetailsViewModel> Select()
        {
            return this.Model.Tourneys;
        }

        public void Update(int id)
        {
            var item = this.Model.Tourneys.FirstOrDefault(p => p.Id == id);

            if (item != null)
            {
                TryUpdateModel(item);

                if (ModelState.IsValid)
                {
                    this.EditTourney?.Invoke(this, new EditTourneyEventArgs(item));
                }
            }
        }

    }
}