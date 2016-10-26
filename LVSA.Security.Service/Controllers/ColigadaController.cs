using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using LVSA.Base.Application.Exceptions;

namespace LVSA.Security.Service.Controllers
{
    public class ColigadaController : AutenticaController
    {
        // GET: api/Coligada
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _contextoAppService.ObterTodasColigada());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // POST: api/Coligada
        public HttpResponseMessage Post(short id)
        {
            try
            {
                var coligada = Seguranca.ColigadaSet.Where(w => w.Id == id).SingleOrDefault();
                if (coligada == null)
                    throw new NoRecordsFoundException("Registro não encontrado");

                Seguranca.Coligada = coligada;

                return Request.CreateResponse(HttpStatusCode.OK, Seguranca.FilialSet);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}