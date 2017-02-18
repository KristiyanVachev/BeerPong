using System.IO;
using System.Reflection;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace BeerPong.Web.App_Start.NinjectModules
{
    public class DefaultNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(x =>
            {
                {
                    var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    x.FromAssembliesInPath(path)
                      .SelectAllClasses()
                      .BindDefaultInterface();
                }
            });
        }
    }
}