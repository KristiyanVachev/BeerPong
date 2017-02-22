using System;
using System.Collections.Generic;
using System.Web.Security;
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
        public event EventHandler<EndTourneyEventArgs> MyEndTourney;

        private bool userHasJoined = false;
        private bool userIsOwner = false;
        private string status = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int tourneyId = int.Parse(this.Request.QueryString["id"]);

                var args = new TourneyDetailsEventArgs(tourneyId, this.Context);

                this.MyTourneyDetails?.Invoke(this, args);

                this.TourneyName.InnerText = this.Model.Name;

                this.status = this.Model.Status;
                this.TourneyStatus.InnerText = this.Model.Status;

                if (Request.IsAuthenticated && this.status == "Open")
                {
                    this.OnOpenEvent.Visible = true;
                }

                this.userHasJoined = this.Model.HasJoined;

                if (userHasJoined)
                {
                    this.JoinButton.Text = "Leave";
                }

                this.userIsOwner = this.Model.IsOwner;

                if (this.userIsOwner && this.status != "Finished")
                {
                    this.OwnerOptions.Visible = true;
                }
            }
            catch (Exception)
            {
                this.Response.Redirect($"/Tourney/TourneyList");
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

        protected void EndTourneyButton_Click(object sender, EventArgs e)
        {
            var winnerName = this.PlayersDropDown.SelectedValue;
            int tourneyId = this.Model.Id;

            var args = new EndTourneyEventArgs(tourneyId, winnerName);
            this.MyEndTourney.Invoke(this, args);
        }

        public IEnumerable<string> BindPlayers()
        {
            return this.Model.Players;
        }
    }
}