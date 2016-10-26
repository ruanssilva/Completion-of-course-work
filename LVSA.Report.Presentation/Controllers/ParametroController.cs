

using LVSA.Base.Presentation.ViewModels;
using LVSA.Report.Application.Interfaces;
using LVSA.Report.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Report.Presentation.Controllers
{
    public class ParametroController : ControllerBase
    {
        private readonly IParametroAppService _parametroAppService;

        public ParametroController(IParametroAppService parametroAppService)
        {
            _parametroAppService = parametroAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _parametroAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: Parametro
        public ActionResult Index()
        {
            try
            {
                IEnumerable<ParametroViewModel> model = _parametroAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Parametro/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                ParametroViewModel model = _parametroAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: Parametro/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Parametro/Create
        [HttpPost]
        public ActionResult Create(ParametroViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);
                // TODO: Add insert logic here
                _parametroAppService.Incluir(model);

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

            return RedirectToAction("Index");
        }

        // GET: Parametro/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ParametroViewModel model = _parametroAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Parametro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ParametroViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);
                // TODO: Add update logic here
                _parametroAppService.Atualizar(model);

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

            return RedirectToAction("Index");
        }

        // GET: Parametro/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ParametroViewModel model = _parametroAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Parametro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ParametroViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _parametroAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _parametroAppService.Remover(model);

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

            return RedirectToAction("Index");
        }
    }
}
