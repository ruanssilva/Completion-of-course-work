using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LVSA.Security.Service.Models;

namespace LVSA.Security.Service.Controllers
{
    public class LogController : AutenticaController
    {
        // POST: api/Log
        public HttpResponseMessage Post(Log model)
        {
            try
            {
                if (model != null)
                {
                    var logs = Logs;

                    model.CODUSUARIO = Seguranca.CODUSUARIO;
                    model.Horario = DateTime.Now;

                    logs.Add(model);

                    Logs = logs;
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
