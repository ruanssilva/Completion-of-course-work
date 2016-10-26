using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LVSA.Base.Infrastructure.CrossCutting.Utility.String.Security;

namespace LVSA.Base.Presentation.Hub
{
    public class StalkerHub : HubBase
    {
        public void WhereIam(string action, string controller, string uri, int minutes)
        {
            if (Contexto != null)
            {
                Clients.All
                    .WhereIam("teste" , action.RemoveTagHtml(), controller.RemoveTagHtml(), uri, minutes);
            }
        }
    }
}