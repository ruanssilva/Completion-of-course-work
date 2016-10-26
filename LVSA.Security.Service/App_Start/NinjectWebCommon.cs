[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(LVSA.Security.Service.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(LVSA.Security.Service.App_Start.NinjectWebCommon), "Stop")]

namespace LVSA.Security.Service.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Http;

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
            //CreateKernel();
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
            var kernel = RegisterServices();

            GlobalConfiguration.Configuration.DependencyResolver = kernel.Get<System.Web.Http.Dependencies.IDependencyResolver>();

            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                //RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public static IKernel RegisterServices(/*IKernel kernel*/)
        {
            return new StandardKernel(
                new LVSA.Base.Infrastructure.CrossCutting.IoC.Application.Modules(),
                new LVSA.Base.Infrastructure.CrossCutting.IoC.Domain.Modules(),
                new LVSA.Security.Infrastructure.CrossCutting.IoC.Application.Modules(),
                new LVSA.Security.Infrastructure.CrossCutting.IoC.Domain.Modules(),
                new LVSA.Noticia.Infrastructure.CrossCutting.IoC.Domain.Modules(),
                new LVSA.Noticia.Infrastructure.CrossCutting.IoC.Application.Modules()
            );
        }
    }
}
