using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LVSA.Base.Presentation.Hub
{
    public class LoadingHub : HubBase
    {
        public void Loading(string message)
        {
            if (Contexto != null)
            {
                Clients.Clients(Connection(Contexto.Seguranca.Usuario.Id.ToString()).ToList())
                    .Loading(message);
            }
        }

        public void Hide()
        {
            if (Contexto != null)
            {
                Clients.Clients(Connection(Contexto.Seguranca.Usuario.Id.ToString()).ToList())
                    .Hide();
            }
        }
    }
}