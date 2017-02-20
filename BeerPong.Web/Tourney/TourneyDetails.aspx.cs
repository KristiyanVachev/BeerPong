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

        private bool userHasJoined = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int tourneyId = int.Parse(this.Request.QueryString["id"]);

                var args = new TourneyDetailsEventArgs(tourneyId, this.Context);

                this.MyTourneyDetails?.Invoke(this, args);

                this.userHasJoined = this.Model.HasJoined;

                this.TourneyName.InnerText = this.Model.Name;

                //TODO hide if userHasJoined is not assigned
                if (userHasJoined)
                {
                    this.JoinButton.Text = "Leave";
                }

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
            var args = new JoinTourneyEventArgs(userHasJoined, Model.Id, this.Context);

            this.JoinTourney.Invoke(this, args);
            userHasJoined = this.Model.HasJoined;

            if (userHasJoined)
            {
                this.JoinButton.Text = "Leave";
            }
            else
            {
                this.JoinButton.Text = "Join";
            }
        }
    }
}