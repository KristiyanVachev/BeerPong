using System.Data.Entity;
using BeerPong.Data;
using BeerPong.Data.Contracts;
using BeerPong.Services;
using BeerPong.Services.Contracts;
using Ninject.Modules;
using Ninject.Web.Common;

namespace BeerPong.Web.App_Start.NinjectModules
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUnitOfWork>().To<UnitOfWork>();
            this.Bind(typeof(IRepository<>)).To(typeof(Repository<>));

            this.Bind<DbContext>().To<BeerPongDbContext>().InRequestScope();

            this.Bind<ITourneyService>().To<TourneyService>();
        }
    }
}