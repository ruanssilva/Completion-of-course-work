using LVSA.Global.Domain.Interfaces.Infra;
using LVSA.Global.Infrastructure.Data.DbContexts;
using System.Web;

namespace LVSA.Global.Infrastructure.Data.Config
{
    public class ContextManager : IContextManager
    {
        public const string HttpGlobalContext = "HttpGlobalContext";

        public GlobalContext GlobalContext
        {
            get
            {
                if (HttpContext.Current.Items[HttpGlobalContext] == null)
                {
                    HttpContext.Current.Items[HttpGlobalContext] = new GlobalContext();
                }
                return HttpContext.Current.Items[HttpGlobalContext] as GlobalContext;
            }
        }

        public void Finish()
        {
            if (HttpContext.Current.Items[HttpGlobalContext] != null)
            {
                (HttpContext.Current.Items[HttpGlobalContext] as GlobalContext).Dispose();
            }
        }
    }
}
