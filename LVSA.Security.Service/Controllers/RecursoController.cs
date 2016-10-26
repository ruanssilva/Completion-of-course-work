using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LVSA.Security.Service.Controllers
{
    public class RecursoController : AutenticaController
    {
        // GET: api/Recurso
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Seguranca.RecursoSet);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // GET: api/Recurso/5
        public HttpResponseMessage Get(long id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Seguranca.RecursoSet.Where(w => w.Id == id).Single());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //// POST: api/Recurso
        //public HttpResponseMessage Post(long id)
        //{
        //    try
        //    {
        //        var recurso = Seguranca.RecursoSet.Where(w => w.Id == id).SingleOrDefault();
        //        if (recurso == null)
        //            throw new Exception("Registro não encontrado");

        //        Seguranca.Filial = recurso;

        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}
    }
}
