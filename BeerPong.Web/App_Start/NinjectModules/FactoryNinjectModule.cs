using BeerPong.Factories;
using BeerPong.MVP;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Web.Common;

namespace BeerPong.Web.App_Start.NinjectModules
{
    public class FactoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ITourneyFactory>().ToFactory().InRequestScope();

            this.Bind<IViewModelFactory>().ToFactory().InRequestScope();
        }
    }
}