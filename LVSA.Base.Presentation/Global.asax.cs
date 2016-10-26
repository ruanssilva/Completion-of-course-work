using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;

namespace LVSA.Base.Presentation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected virtual void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            LVSA.Noticia.Application.AutoMapper.AutoMapperConfig.RegisterMappings();
            LVSA.Security.Application.AutoMapper.AutoMapperConfig.RegisterMappings();
        }
    }
}
