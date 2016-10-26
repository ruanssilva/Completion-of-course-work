using LVSA.Global.Application.AutoMapper;
using Ninject.Modules;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LVSA.Global.Presentation
{
    public class MvcApplication : LVSA.Base.Presentation.MvcApplication
    {
        protected override void Application_Start()
        {
            LVSA.Global.Application.AutoMapper.AutoMapperConfig.RegisterMappings();

            base.Application_Start();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);



            LVSA.Base.Presentation.App_Start.NinjectWebCommon.Kernel.Load(new List<NinjectModule> {
                new LVSA.Global.Infrastructure.CrossCutting.IoC.Domain.Modules(),
                new LVSA.Global.Infrastructure.CrossCutting.IoC.Application.Modules()
            });
        }
    }
}
