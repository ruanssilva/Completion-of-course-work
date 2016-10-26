[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(LVSA.Base.Presentation.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(LVSA.Base.Presentation.App_Start.NinjectWebCommon), "Stop")]

namespace LVSA.Base.Presentation.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Collections.Generic;
    using Ninject.Modules;

    public static partial class NinjectWebCommon
    {
        private static IKernel _kernel;
        public static IKernel Kernel { get { return _kernel; } set { _kernel = value; } }

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
        public static IKernel CreateKernel()
        {
            if (_kernel == null)
                _kernel = RegisterServices();

            try
            {
                _kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                _kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                //RegisterServices(kernel);
                return _kernel;
            }
            catch
            {
                _kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public static IKernel RegisterServices(/*IKernel kernel*/)
        {
            var kernel = new StandardKernel(
                new LVSA.Base.Infrastructure.CrossCutting.IoC.Application.Modules(),
                new LVSA.Base.Infrastructure.CrossCutting.IoC.Domain.Modules(),
                new LVSA.Security.Infrastructure.CrossCutting.IoC.Application.Modules(),
                new LVSA.Security.Infrastructure.CrossCutting.IoC.Domain.Modules(),

                new LVSA.Noticia.Infrastructure.CrossCutting.IoC.Application.Modules(),
                new LVSA.Noticia.Infrastructure.CrossCutting.IoC.Domain.Modules()
            );

            return kernel;
        }
    }
}
