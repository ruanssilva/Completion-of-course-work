using LVSA.Base.Presentation.ViewModels;
using LVSA.Farm.Application.Interfaces;
using LVSA.Farm.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Farm.Presentation.Controllers
{
    public class TerrenoController : ControllerBase
    {
        private readonly ITerrenoAppService _terrenoAppService;

        public TerrenoController(ITerrenoAppService terrenoAppService)
        {
            _terrenoAppService = terrenoAppService;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            AddShortcut("Ir para pastos", Url.Action("Index", "Pasto"), "fa fa-arrow-left");
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Contexto.IsAuthentication())
            {
                _terrenoAppService.SetSeguranca(Contexto.Seguranca);
            }
        }

        // GET: Terreno
        public ActionResult Details()
        {
            try
            {
                var model = _terrenoAppService.Obter();

                return View("Details", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit()
        {
            try
            {
                var model = _terrenoAppService.Obter();

                return View("Edit", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Details");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TerrenoViewModel model, HttpPostedFileBase[] FileSet)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Edit", model);

                _terrenoAppService.Atualizar(model);

                Gritters.Add(new GritterViewModel
                {
                    Tittle = "Sucesso!",
                    Message = "Operação realizada com sucesso.",
                    Style = GritterStyle.Success,
                });
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Details");
        }
    }
}