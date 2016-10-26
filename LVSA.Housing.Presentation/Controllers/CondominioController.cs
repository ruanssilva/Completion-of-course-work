

using LVSA.Base.Presentation.ViewModels;
using LVSA.Housing.Application.Interfaces;
using LVSA.Housing.Application.ViewModels;
using LVSA.Housing.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Housing.Presentation.Controllers
{
    public class CondominioController : ControllerBase
    {
        private readonly ICondominioAppService _condominioAppService;

        public CondominioController(ICondominioAppService condominioAppService)
        {
            _condominioAppService = condominioAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _condominioAppService.SetSeguranca(Contexto.Seguranca);
        }

        public ActionResult Index()
        {
            return Details();
        }

        // GET: Condominio/Details/5
        public ActionResult Details()
        {
            try
            {
                CondominioViewModel model = _condominioAppService.Obter();
                if (model == null)
                    return View(new CondominioViewModel { });

                return View("Details", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: Condominio/Edit/5
        public ActionResult Edit()
        {
            try
            {
                var x = AutoMapper.Mapper.Map<CondominioViewModel, Condominio>(new CondominioViewModel { });

                CondominioViewModel model = _condominioAppService.Obter();
                if (model == null)
                    model = _condominioAppService.Incluir(new CondominioViewModel { });

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Condominio/Edit/5
        [HttpPost]
        public ActionResult Edit(CondominioViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                // TODO: Add update logic here
                _condominioAppService.Atualizar(model);

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
