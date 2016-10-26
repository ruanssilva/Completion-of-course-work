using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(LVSA.Base.Presentation.Startup))]

namespace LVSA.Base.Presentation
{
    public class Startup
    {
        public virtual void Configuration(IAppBuilder app)
        {
            GlobalHost.Configuration.ConnectionTimeout = TimeSpan.FromSeconds(10);
            GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => new LVSA.Base.Presentation.Hub.UserIdProvider());
            
            app.MapSignalR();
        }
    }
}
