using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using LVSA.Base.Infrastructure.CrossCutting.Utility.String.Security;
using LVSA.Base.Presentation.Models;

namespace LVSA.Base.Presentation.Hub
{
    public class GritterHub : HubBase
    {
        /// <summary>
        /// Acionar método Ask nos clientes conectados
        /// </summary>
        /// <param name="id">Para enviar a um cliente especifico</param>
        /// <param name="title">Título</param>
        /// <param name="message">Texto</param>
        public void Ask(string id, string title, string message)
        {
            if (Contexto != null)
            {
                //string _id = Users.Where(w => w.Value.Contains(Context.ConnectionId))
                //                    .Select(s => s.Key)
                //                    .FirstOrDefault();

                if (!string.IsNullOrWhiteSpace(id))
                    Clients.Clients(Connection(id).ToList())
                        .Ask(Contexto.Seguranca.Usuario.Id.ToString().RemoveTagHtml(), title.RemoveTagHtml(), message.RemoveTagHtml());
                else
                    Clients.All
                        .Ask(Contexto.Seguranca.Usuario.Id.ToString().RemoveTagHtml(), title.RemoveTagHtml(), message.RemoveTagHtml());
            }
        }

        /// <summary>
        /// Acionar método Answer nos clientes conectados
        /// </summary>
        /// <param name="id">Para enviar a um cliente especifico</param>
        /// <param name="title">Título</param>
        /// <param name="message">Texto</param>
        /// <param name="answer">Resposta</param>
        public void Answer(string id, string title, string message, string answer)
        {
            if (Contexto != null)
            {
                if (!string.IsNullOrEmpty(id))
                    Clients.Clients(Connection(id).ToList()).Answer(title.RemoveTagHtml(), message.RemoveTagHtml(), answer.RemoveTagHtml());
            }
        }

        /// <summary>
        /// Acionar método Information nos clientes conectados
        /// </summary>
        /// <param name="id">Para enviar a um cliente especifico</param>
        /// <param name="title">Título</param>
        /// <param name="message">Texto</param>
        public void Information(string id, string title, string message)
        {
            if (Contexto != null)
            {
                if (!string.IsNullOrWhiteSpace(id))
                    Clients.Clients(Connection(id).ToList()).Information(title.RemoveTagHtml(), message.RemoveTagHtml());
                else
                    Clients.All.Information(title.RemoveTagHtml(), message.RemoveTagHtml());
            }
        }
    }
}