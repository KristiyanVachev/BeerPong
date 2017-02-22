using System;
using BeerPong.MVP.Tourney.Create;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace BeerPong.Web.Tourney
{
    [PresenterBinding(typeof(CreateTourneyPresenter))]
    public partial class CreateTourney : MvpPage<CreateTourneyViewModel>, ICreateTourneyView
    {

        public event EventHandler<CreateTourneyEventArgs> CreateTourney;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                this.Response.Redirect($"/Account/Login");
            }
        }

        protected void CreateTourney_Click(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                this.Response.Redirect($"/Account/Login");
            }

            var name = this.Name.Text;

            var args = new CreateTourneyEventArgs(name, this.Context);

            this.CreateTourney?.Invoke(this, args);
            
            this.Response.Redirect($"/Tourney/TourneyDetails?id={Model.Id}");
        }
    }
}