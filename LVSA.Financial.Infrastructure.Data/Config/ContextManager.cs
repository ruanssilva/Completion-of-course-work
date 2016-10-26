using LVSA.Financial.Domain.Interfaces.Infra;
using LVSA.Financial.Infrastructure.Data.DbContexts;
using System.Web;

namespace LVSA.FInancial.Infrastructure.Data.Config
{
    public class ContextManager : IContextManager
    {
        public const string HttpGlobalContext = "HttpFinancialContext";

        public FinancialContext GlobalContext
        {
            get
            {
                if (HttpContext.Current.Items[HttpGlobalContext] == null)
                {
                    HttpContext.Current.Items[HttpGlobalContext] = new FinancialContext();
                }
                return HttpContext.Current.Items[HttpGlobalContext] as FinancialContext;
            }
        }

        public void Finish()
        {
            if (HttpContext.Current.Items[HttpGlobalContext] != null)
            {
                (HttpContext.Current.Items[HttpGlobalContext] as FinancialContext).Dispose();
            }
        }
    }
}
