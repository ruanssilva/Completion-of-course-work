

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
    public class CategoriaCuboController : ControllerBase
    {
        private readonly ICategoriaCuboAppService _categoriaCuboAppService;

        public CategoriaCuboController(ICategoriaCuboAppService categoriaCuboAppService)
        {
            _categoriaCuboAppService = categoriaCuboAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _categoriaCuboAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: CategoriaCubo
        public ActionResult Index()
        {
            try
            {
                IEnumerable<CategoriaCuboViewModel> model = _categoriaCuboAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: CategoriaCubo/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                CategoriaCuboViewModel model = _categoriaCuboAppService.ObterPorId(id);
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

        // GET: CategoriaCubo/Create
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

        // POST: CategoriaCubo/Create
        [HttpPost]
        public ActionResult Create(CategoriaCuboViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                // TODO: Add insert logic here
                _categoriaCuboAppService.Incluir(model);

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

        // GET: CategoriaCubo/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                CategoriaCuboViewModel model = _categoriaCuboAppService.ObterPorId(id);
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

        // POST: CategoriaCubo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoriaCuboViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                // TODO: Add update logic here
                _categoriaCuboAppService.Atualizar(model);

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

        // GET: CategoriaCubo/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                CategoriaCuboViewModel model = _categoriaCuboAppService.ObterPorId(id);
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

        // POST: CategoriaCubo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CategoriaCuboViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _categoriaCuboAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _categoriaCuboAppService.Remover(model);

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
