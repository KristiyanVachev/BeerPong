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

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int tourneyId = int.Parse(this.Request.QueryString["id"]);

                var args = new TourneyDetailsEventArgs(tourneyId, this.Context);

                this.MyTourneyDetails?.Invoke(this, args);

                this.TourneyName.InnerText = this.Model.Name;
                this.TourneyStatus.InnerText = this.Model.Status;

                //TODO userIsLogged and tourney is open
                if (Request.IsAuthenticated)
                {
                    this.OnOpenEvent.Visible = true;
                }

                this.userHasJoined = this.Model.HasJoined;
                //TODO hide if userHasJoined is not assigned
                if (userHasJoined)
                {
                    this.JoinButton.Text = "Leave";
                }

                //TODO If username is the same as tourney's creator, display start game button
                this.userIsOwner = this.Model.IsOwner;

                if (this.userIsOwner)
                {
                    this.OwnerOptions.Visible = true;
                }
                

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


        protected void StartTourneyButton_Click(object sender, EventArgs e)
        {

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