using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net;
using System.Web.Configuration;
using LVSA.Security.Application.Models;

namespace LVSA.Security.Service.Controllers
{
    public class ContextoController : AutenticaController
    {

        public HttpResponseMessage Get()
        {
            try
            {
                string ambiente = WebConfigurationManager.AppSettings["LVSA.Security.Application.Models.Ambiente"];
                
                if (ambiente == "Desenvolvimento")
                    Seguranca.Ambiente = Ambiente.Desenvolvimento;
                else if (ambiente == "Homologacao")
                    Seguranca.Ambiente = Ambiente.Homologacao;
                else if (ambiente == "Producao")
                    Seguranca.Ambiente = Ambiente.Producao;

                return Request.CreateResponse(HttpStatusCode.OK, Seguranca);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Post(bool id)
        {
            try
            {
                if (id)
                    SignOut();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


    }
}