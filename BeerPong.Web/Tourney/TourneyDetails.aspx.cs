using System;
using BeerPong.MVP.Tourney.Details;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace BeerPong.Web.Tourney
{
    [PresenterBinding(typeof(TourneyDetailsPresenter))]
    public partial class TourneyDetails : MvpPage<TourneyDetailsViewModel>, ITourneyDetailsView
    {
        public event EventHandler<TourneyDetailsEventArgs> MyTourneyDetails;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int tourneyId = int.Parse(this.Request.QueryString["id"]);

                var args = new TourneyDetailsEventArgs(tourneyId);

                this.MyTourneyDetails?.Invoke(this, args);

                this.TourneyName.InnerText = this.Model.Name;
            }
            catch (Exception)
            {
                //TODO show error message
                return;
            }
        }

    }
}