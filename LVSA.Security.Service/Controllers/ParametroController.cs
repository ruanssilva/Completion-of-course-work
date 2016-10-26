using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using LVSA.Base.Application.Interfaces;
using LVSA.Security.Service.App_Start;
using Ninject;
using Ninject.Web.Common;

namespace LVSA.Security.Service.Controllers
{
    public class ParametroController : AutenticaController
    {
        private readonly IReadOnlyAppService _readOnlyAppService;

        public ParametroController()
        {
            _readOnlyAppService = NinjectWebCommon.RegisterServices().Get<IReadOnlyAppService>(); ;
        }

        // GET: api/Parametro
        public HttpResponseMessage Get(string id)
        {
            try
            {
                if (Seguranca.Aplicacao != null && Seguranca.Aplicacao.ParametroSet != null)
                {
                    var parametro = Seguranca.Aplicacao.ParametroSet.Where(w => w.Codigo == id).SingleOrDefault();
                    if (parametro == null)
                        return Request.CreateResponse(HttpStatusCode.OK, new { });

                    if (!string.IsNullOrWhiteSpace(parametro.TSQL))
                    {
                        foreach (var p in Seguranca.Parametros)
                            if (!string.IsNullOrWhiteSpace(p.Value))
                                parametro.TSQL = parametro.TSQL.Replace("[#" + p.Key + "]", p.Value);

                        if (!parametro.TSQL.Contains("[#"))
                            return Request.CreateResponse(HttpStatusCode.OK, _readOnlyAppService.Query<dynamic>(parametro.TSQL));
                    }

                    return Request.CreateResponse(HttpStatusCode.OK, new { });
                }
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new { });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // POST: api/Parametro
        public HttpResponseMessage Post(string key, string value = null)
        {
            try
            {
                if (!Seguranca.Parametros.ContainsKey(key))
                    Seguranca.Parametros.Add(key, value);
                else
                    Seguranca.Parametros[key] = value;

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}