using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LVSA.Farm.Presentation
{
    public class MvcApplication : LVSA.Base.Presentation.MvcApplication
    {
        protected override void Application_Start()
        {
            LVSA.Global.Application.AutoMapper.AutoMapperConfig.RegisterMappings();
            LVSA.Financial.Application.AutoMapper.AutoMapperConfig.RegisterMappings();
            LVSA.Farm.Application.AutoMapper.AutoMapperConfig.RegisterMappings();
            

            base.Application_Start();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            LVSA.Base.Presentation.App_Start.NinjectWebCommon.Kernel.Load(new List<NinjectModule> {
                new LVSA.Farm.Infrastructure.CrossCutting.IoC.Domain.Modules(),
                new LVSA.Global.Infrastructure.CrossCutting.IoC.Domain.Modules(),
                new LVSA.Global.Infrastructure.CrossCutting.IoC.Application.Modules(),
                new LVSA.Farm.Infrastructure.CrossCutting.IoC.Application.Modules(),
                new LVSA.Financial.Infrastructure.CrossCutting.IoC.Application.Modules(),
                new LVSA.Financial.Infrastructure.CrossCutting.IoC.Domain.Modules()
            });
        }
    }
}
