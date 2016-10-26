using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LVSA.Security.Application.Models;

namespace LVSA.Security.Service.Controllers
{
    public class DSegurancaController : DesenvolvedorController
    {
        // GET: api/DSeguranca
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Segurancas);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // GET: api/DSeguranca/5
        public HttpResponseMessage Get(long id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Segurancas
                    .Where(w => w.Usuario.Id == id)
                    .SingleOrDefault()
                );
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // POST: api/DSeguranca
        public HttpResponseMessage Post()
        {
            try
            {
                

                LVSA.Security.Application.Models.Seguranca.SetAplicacaoSet(null);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/DSeguranca/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DSeguranca/5
        public void Delete(int id)
        {
        }
    }
}
