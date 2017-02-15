using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeerPong.Web.Startup))]
namespace BeerPong.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
