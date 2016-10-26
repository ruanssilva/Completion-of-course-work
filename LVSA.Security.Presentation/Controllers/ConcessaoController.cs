using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LVSA.Base.Presentation.ViewModels;
using LVSA.Security.Application.Models;
using LVSA.Security.Application.ViewModels;
using LVSA.Security.Presentation.ViewModels;

namespace LVSA.Security.Presentation.Controllers
{
    public class ConcessaoController : FiltroController
    {
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            ViewBag.FilialId = FFilialId;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            AddShortcut("Ir para aplicações", Url.Action("Index", "Aplicacao"), "fa fa-cubes");
            AddShortcut("Ir para grupos", Url.Action("Index", "Grupo"), "fa fa-users");
        }

        public ActionResult Aplicacao()
        {
            try
            {
                ModelState.Clear();

                ConcessoesViewModel model = new ConcessoesViewModel { };

                FFilialId = null;

                ViewBag.FilialId = FFilialId;

                return View("Aplicacao", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Aplicacao(ConcessoesViewModel model)
        {
            try
            {
                if (FFilialId != null)
                    ViewBag.AplicacaoSet = _aplicacaoAppService.Filtrar(f => f.Ativo && !f.Abstrata && f.Ativo);

                if (FFilialId != null)
                {
                    if (model.AplicacaoSet != null)
                    {
                        var filial = _contextoAppService.ObterTodasFilial().Where(w => w.Id == FFilialId).Single();
                        filial.AplicacaoSet = model.AplicacaoSet;
                        _contextoAppService.Conceder(filial);

                        Gritters.Add(new GritterViewModel
                        {
                            Tittle = "Sucesso!",
                            Message = "Operação realizada com sucesso.",
                            Style = GritterStyle.Success,
                        });

                        model.AplicacaoSet = model.AplicacaoSet.Where(w => w.Selecionado);
                    }
                    else
                        model.AplicacaoSet = _contextoAppService.Acessos(f => f.FilialId == FFilialId && f.Ativo);
                }

                return View("Aplicacao", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}