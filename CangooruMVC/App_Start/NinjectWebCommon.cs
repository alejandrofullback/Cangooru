[assembly: WebActivator.PreApplicationStartMethod(typeof(CangooruMVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(CangooruMVC.App_Start.NinjectWebCommon), "Stop")]

namespace CangooruMVC.App_Start
{
    using System;
    using System.Web;
    using Cangooru.Repositories;
    using Cangooru.Repositories.Interfaces;
    using Cangooru.Services;
    using Cangooru.Services.Interfaces;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Cangooru.Repositories.Location;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IOrderService>().To<OrderService>();
            kernel.Bind<IOrderRepository>().To<Cangooru.Repositories.Order.OrderRepository>();

            kernel.Bind<ILocationsService>().To<LocationsService>();
            kernel.Bind<ILocationRepository>().To<LocationRepository>();
        }
    }
}
