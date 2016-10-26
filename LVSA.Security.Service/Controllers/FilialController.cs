using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net;
using LVSA.Security.Application.Models;
using LVSA.Security.Application.ViewModels;

namespace LVSA.Security.Service.Controllers
{
    public class FilialController : AutenticaController
    {
        // GET: api/Filial
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _contextoAppService.ObterTodasFilial());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // GET: api/Filial/5
        public HttpResponseMessage Get(short id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Seguranca.FilialSet.Where(w => w.Id == id).SingleOrDefault());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // POST: api/Filial
        public HttpResponseMessage Post(short id)
        {
            try
            {
                var filial = Seguranca.FilialSet.Where(w => w.Id == id).SingleOrDefault();
                if (filial == null)
                    throw new Exception("Registro não encontrado");


                Seguranca.Filial = filial;

                

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
