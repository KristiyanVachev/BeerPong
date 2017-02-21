using System;
using BeerPong.MVP.Tourney.Create;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace BeerPong.Web.Tourney
{
    [PresenterBinding(typeof(CreateTourneyPresenter))]
    public partial class CreateTourney : MvpPage<CreateTourneyViewModel>, ICreateTourneyView
    {

        public event EventHandler<CreateTourneyEventArgs> MyCreateTourney;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateTourney_Click(object sender, EventArgs e)
        {
            var name = this.Name.Text;

            var args = new CreateTourneyEventArgs(name);

            this.MyCreateTourney?.Invoke(this, args);
            
            this.Response.Redirect($"/Tourney/TourneyDetails?id={Model.Id}");
        }

    }
}