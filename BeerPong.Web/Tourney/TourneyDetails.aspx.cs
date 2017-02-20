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
        public event EventHandler<JoinTourneyEventArgs> JoinTourney;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int tourneyId = int.Parse(this.Request.QueryString["id"]);

                var args = new TourneyDetailsEventArgs(tourneyId);

                this.MyTourneyDetails?.Invoke(this, args);

                this.TourneyName.InnerText = this.Model.Name;

                //TODO: If user has joined, display leave tourney
                //Model.IsJoined
                //TODO If username is the same as tourney's creator, display start game button
            }
            catch (Exception)
            {
                //TODO show error message
                return;
            }
        }

        protected void JoinButton_Click(object sender, EventArgs e)
        {
            //TODO extract model.Id
            var args = new JoinTourneyEventArgs(false, Model.Id, this.Context);

            this.JoinTourney.Invoke(this, args);
        }
    }
}