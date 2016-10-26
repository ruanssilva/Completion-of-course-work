using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LVSA.Base.Presentation.ViewModels;

namespace LVSA.Base.Presentation.Controllers
{
    public class ParamController : AutenticaController
    {
        // GET: Param
        public ActionResult Index()
        {
            try
            {
                //Gritters.Add(new GritterViewModel
                //{
                //    Tittle = "Aplicação com parâmetro",
                //    Message = "Está aplicação disponibiliza alguns parâmetros para serem informados pelo usuário. Forneça os parâmetros obrigatórios e caso necessite os opcionais.",
                //    Style = GritterStyle.Information
                //});

                List<ParamViewModel> model = new List<ParamViewModel> { };
                if (Contexto.Seguranca.Aplicacao != null)
                    foreach (var k in Contexto.Seguranca.Aplicacao.ParametroSet.OrderBy(o => o.Sequencia))
                        model.Add(Contexto.GetParam(k.Codigo));

                foreach (var k in model)
                    if (k.Multi && k.Value != null)
                        k.Values = k.Value.Split(',');

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST: Param
        [HttpPost]
        public ActionResult Index(IEnumerable<ParamViewModel> model, string Selecionar)
        {
            try
            {
                if (Contexto.Seguranca.Aplicacao != null)
                {
                    string[] keys = Contexto.Seguranca.Aplicacao.ParametroSet.Where(w => w.Obrigatorio).Select(s => s.Codigo).ToArray();


                    foreach (var w in model)
                        if (keys.Contains(w.Key) && (w.Values == null || w.Values.Count() == 0) && string.IsNullOrWhiteSpace(w.Value))
                        {
                            ModelState.AddModelError(w.Key, "Parâmetro obrigatório");
                            Contexto.SetParam(w.Key, "");
                        }
                        else
                            Contexto.SetParam(w.Key, w.Values != null ? string.Join(",", w.Values) : w.Value);

                    Contexto.Reload();

                    if (!ModelState.IsValid || Selecionar == null)
                        return Index();
                }
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}