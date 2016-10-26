using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LVSA.Base.Application.Exceptions;
using LVSA.Base.Presentation.Exceptions;
using LVSA.Security.Application.ViewModels;

namespace LVSA.Base.Presentation.Controllers
{
    public class AppController : AutenticaController
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            ViewBag.AplicacaoSet = _aplicacaoRest.Get();
        }

        // GET: Gerenciador
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST: Gerenciador
        [HttpPost]
        public ActionResult Index(int id)
        {
            try
            {

                if (((IEnumerable<AplicacaoViewModel>)ViewBag.AplicacaoSet).Select(s => s.Id).Contains(id))
                {
                    var aplicacao = Contexto.Seguranca.AplicacaoSet.Where(w => w.Id == id).First();
                    Contexto.SetAplicacao(aplicacao);
                    return Redirect(aplicacao.Link);
                }

                throw new NoRecordsFoundException("A aplicação não foi encontrada");
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }
    }
}