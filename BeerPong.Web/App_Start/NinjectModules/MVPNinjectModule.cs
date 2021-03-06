﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerPong.Web.App_Start.Factories;
using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Parameters;
using WebFormsMvp;
using WebFormsMvp.Binder;

namespace BeerPong.Web.App_Start.NinjectModules
{
    public class MvpNinjectModule : NinjectModule
    {
        private const string ViewConstructorArgumentName = "view";

        public override void Load()
        {
            this.Bind<IPresenterFactory>().To<WebFormsMvpPresenterFactory>().InSingletonScope();
            this.Bind<ICustomPresenterFactory>().ToFactory().InSingletonScope();
            this.Bind<IPresenter>()
                .ToMethod(this.GetPresenter)
                .NamedLikeFactoryMethod((ICustomPresenterFactory factory) => factory.GetPresenter(null, null));
        }

        private IPresenter GetPresenter(IContext context)
        {
            var parameters = context.Parameters.ToList();

            var presenterType = (Type)parameters[0].GetValue(context, null);
            var viewInstance = (IView)parameters[1].GetValue(context, null);

            var constructorParameter = new ConstructorArgument(ViewConstructorArgumentName, viewInstance);

            var presenter = (IPresenter)context.Kernel.Get(presenterType, constructorParameter);
            return presenter;
        }
    }
}