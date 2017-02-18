using System;
using WebFormsMvp;

namespace BeerPong.Web.App_Start.Factories
{
    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}