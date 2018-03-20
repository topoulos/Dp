using System.Web.Http;
using Dp.Models.Database;
using Dp.Repository.DAL;
using Dp.Services;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace Dp.Api.IoC
{
    public static class DpIoCProvider
    {
        public static Container CreateRequestContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new SimpleInjector.Lifestyles.AsyncScopedLifestyle();

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);


            container.Register<IRepository<TaskItem>, TaskItemRepository>(Lifestyle.Scoped);
            container.Register<ITaskItemService, TaskItemService>(Lifestyle.Scoped);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            return container;
        }

        public static Container CreateStartupContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new SimpleInjector.Lifestyles.AsyncScopedLifestyle();

            container.Register<IRepository<TaskItem>, TaskItemRepository>(Lifestyle.Scoped);
            container.Register<ITaskItemService, TaskItemService>(Lifestyle.Scoped);

            return container;
        }
    }
}