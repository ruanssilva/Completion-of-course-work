

using LVSA.Base.Presentation.ViewModels;
using LVSA.Housing.Application.Interfaces;
using LVSA.Housing.Application.ViewModels;
using LVSA.Housing.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Housing.Presentation.Controllers
{
    public class MeuCustoController : MoradorControllerBase
    {
        private readonly ICustoMoradiaAppService _custoMoradiaAppService;

        public MeuCustoController(ICustoMoradiaAppService custoMoradiaAppService)
        {
            _custoMoradiaAppService = custoMoradiaAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _custoMoradiaAppService.SetSeguranca(Contexto.Seguranca);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (Morador == null || !Morador.ResponsavelFinanceiro)
            {
                //if (Morador == null)
                //    Notifications.Add(new NotificationViewModel
                //    {
                //        Title = "Você não é um morador.",
                //        Message = "Essa área no sistema é exclusiva para moradores, procure o administrador para mais informações.",
                //        TimeOut = 800,
                //        Center = true,
                //        Position = Position.TopRight,
                //        Status = Status.Info,
                //        Icon = Icon.Info,
                //    });
                //else
                //    Notifications.Add(new NotificationViewModel
                //    {
                //        Title = "Você não é responsável financeiro de sua moradia.",
                //        Message = "Essa área no sistema é exclusiva para responsáveis financeiros, procure o administrador para mais informações.",
                //        TimeOut = 800,
                //        Center = true,
                //        Position = Position.TopRight,
                //        Status = Status.Info,
                //        Icon = Icon.Info,
                //    });

                filterContext.Result = RedirectToAction("Index", "Home");
            }
        }

        // GET: MinhaConta
        public ActionResult Index()
        {
            try
            {
                return View(new CustoMoradiaAppViewModel());
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST: MinhaConta/Index
        [HttpPost]
        public ActionResult Index(CustoMoradiaAppViewModel model)
        {
            try
            {
                model.CustoMoradiaSet = _custoMoradiaAppService.Filtrar(f =>
                    (f.MoradiaId == Morador.MoradiaId) &&
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

        // GET: MinhaConta/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                CustoMoradiaViewModel model = _custoMoradiaAppService.Filtrar(f => f.Id == id && f.MoradiaId == Morador.MoradiaId).SingleOrDefault();
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

        // GET: MinhaConta/Comprovante/5
        public ActionResult Comprovante(int id)
        {
            try
            {
                CustoMoradiaViewModel model = _custoMoradiaAppService.Filtrar(f => f.Id == id && f.MoradiaId == Morador.MoradiaId && f.DataPagamento != null).SingleOrDefault();
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
