//using Dp.Models.Database;
//using Dp.Services;

//[assembly: WebActivator.PostApplicationStartMethod(typeof(Dp.Api.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

//namespace Dp.Api.App_Start
//{
//    using System.Web.Http;
//    using Dp.Repository.DAL;
//    using SimpleInjector;
//    using SimpleInjector.Integration.WebApi;
    
//    public static class SimpleInjectorWebApiInitializer
//    {
//        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
//        public static void Initialize()
//        {
//            var container = new Container();
//            container.Options.DefaultScopedLifestyle = new SimpleInjector.Lifestyles.AsyncScopedLifestyle();
            
//            InitializeContainer(container);

//            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
//            container.Verify();
            
//            GlobalConfiguration.Configuration.DependencyResolver =
//                new SimpleInjectorWebApiDependencyResolver(container);
//        }
     
//        private static void InitializeContainer(Container container)
//        {
//            // For instance:
//            container.Register<ITaskItemService, TaskItemService>(Lifestyle.Scoped);
//            container.Register<IRepository<TaskItem>, TaskItemRepository>(Lifestyle.Scoped);
//        }
//    }
//}