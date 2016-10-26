

using LVSA.Base.Presentation.ViewModels;
using LVSA.Housing.Application.Interfaces;
using LVSA.Housing.Application.ViewModels;
using LVSA.Housing.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Housing.Presentation.Controllers
{
    public class MinhaMultaController : MoradorControllerBase
    {
        private readonly IMultaMoradorAppService _multaMoradorAppService;

        public MinhaMultaController(IMultaMoradorAppService multaMoradorAppService)
        {
            _multaMoradorAppService = multaMoradorAppService;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (Morador == null)
            {
                //Notifications.Add(new NotificationViewModel
                //{
                //    Title = "Você não é um morador.",
                //    Message = "Essa área no sistema é exclusiva para moradores, procure o administrador para mais informações.",
                //    TimeOut = 800,
                //    Center = true,
                //    Position = Position.TopRight,
                //    Status = Status.Info,
                //    Icon = Icon.Info,
                //});

                filterContext.Result = RedirectToAction("Index", "Home");
            }
        }

        // GET: MinhaMulta
        public ActionResult Index()
        {
            try
            {
                return View(new MultaMoradorAppViewModel());
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST: MinhaMulta
        [HttpPost]
        public ActionResult Index(MultaMoradorAppViewModel model)
        {
            try
            {
                model.MultaMoradorSet = _multaMoradorAppService.Filtrar(f =>
                    (f.MoradorId == Morador.Id) &&
                    (model.DataFiltroInicio != null ? f.DataReferencia >= model.DataFiltroInicio : true) &&
                    (model.DataFiltroFinal != null ? f.DataReferencia <= model.DataFiltroFinal : true) &&
                    (model.FiltroPago != null ? (model.FiltroPago == true ? (f.DataPagamento != null) : (f.DataPagamento == null)) : true)
                );

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: MinhaMulta/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                MultaMoradorViewModel model = _multaMoradorAppService.Filtrar(f => f.Id == id && f.MoradorId == Morador.Id).SingleOrDefault();
                if (model == null)
                    throw new ArgumentNullException("model");

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: MinhaMulta/Comprovante/5
        public ActionResult Comprovante(int id)
        {
            try
            {
                MultaMoradorViewModel model = _multaMoradorAppService.Filtrar(f => f.Id == id && f.MoradorId == Morador.Id && f.DataPagamento != null).SingleOrDefault();
                if (model == null)
                    throw new ArgumentNullException("model");

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

    }
}
