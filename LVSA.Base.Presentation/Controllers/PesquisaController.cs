using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Base.Presentation.Controllers
{
    public class PesquisaController : AutenticaController
    {
        // GET: Pesquisa
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        // POST: Pesquisa
        [HttpPost]
        public ActionResult Index(string Pesquisa)
        {
            try
            {
                Dictionary<string, KeyValuePair<string, string>> model = new Dictionary<string, KeyValuePair<string, string>> { };

                foreach (var x in Contexto.Seguranca.RecursoSet.Where(w => !string.IsNullOrWhiteSpace(w.Controller) && !string.IsNullOrWhiteSpace(w.Action) && w.Tags != null && w.Tags.Contains(Pesquisa)))
                    model[x.Exibicao] = new KeyValuePair<string, string>(x.Icon, Url.Action(x.Action, x.Controller));

                ViewBag.Pesquisa = Pesquisa;

                return View("Index", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}