using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LVSA.Base.Presentation.ViewModels;
using LVSA.Security.Application.Models;

namespace LVSA.Base.Presentation.Controllers
{
    public class ContextoController : AutenticaController
    {
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);


            if (Contexto.IsAuthentication())
            {
                //if (Contexto.Seguranca.ColigadaSet.Count() > 1)
                //{
                //    if (requestContext.HttpContext.Request.Form["ColigadaId"] != null && !string.IsNullOrWhiteSpace(requestContext.HttpContext.Request.Form["ColigadaId"]))
                //    {
                //        short ColigadaId = Convert.ToInt16(requestContext.HttpContext.Request.Form["ColigadaId"]);
                //        Contexto.SetColigada(Contexto.Seguranca.ColigadaSet.Where(w => w.Id == ColigadaId).SingleOrDefault());

                //        Contexto.Reload();
                //    }

                //    ViewBag.ColigadaSet = Contexto.Seguranca.ColigadaSet;
                //    ViewBag.ColigadaId = Contexto.Seguranca.ColigadaId;

                //}

                if (requestContext.HttpContext.Request.Form["FilialId"] != null && !string.IsNullOrWhiteSpace(requestContext.HttpContext.Request.Form["FilialId"]))
                {
                    short FilialId = Convert.ToInt16(requestContext.HttpContext.Request.Form["FilialId"]);

                    var filial = Contexto.Seguranca.FilialSet.Where(w => w.Id == FilialId).SingleOrDefault();
                    
                    Contexto.SetColigada(filial.Coligada);
                    Contexto.SetFilial(filial);

                    Contexto.Reload();
                }

                ViewBag.FilialSet = Contexto.Seguranca.FilialSet;
                ViewBag.FilialId = Contexto.Seguranca.FilialId;

            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (Contexto != null && Contexto.Seguranca != null && Contexto.Seguranca.FilialSet != null && Contexto.Seguranca.FilialSet.Count() == 1)
                filterContext.Result = RedirectToAction("Index", "Home");
        }

        // GET: Contexto
        public ActionResult Index()
        {
            try
            {
                if (Contexto.Seguranca.Aplicacao != null && Contexto.Seguranca.Aplicacao.ParametroSet != null)
                {
                    string[] keys = Contexto.Seguranca.Aplicacao.ParametroSet.Where(w => w.Obrigatorio).Select(s => s.Codigo).ToArray();
                    foreach (var key in keys)
                        Contexto.SetParam(key, null);
                }

                Contexto.SetAplicacao(null);

                return View("Index");
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Logout", "Login");
        }

        [HttpPost]
        public ActionResult Index(string id)
        {
            try
            {
                if (Contexto.Seguranca.Coligada != null && Contexto.Seguranca.Filial != null)
                {
                    Seguranca.SetAplicacaoSet(_aplicacaoRest.Get());
                    return RedirectToAction("Index", "Home");
                }

                return View("Index");
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Logout", "Login");
        }
    }
}