

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
    public class CategoriaConsultaController : ControllerBase
    {
        private readonly ICategoriaConsultaAppService _categoriaConsultaAppService;

        public CategoriaConsultaController(ICategoriaConsultaAppService categoriaConsultaAppService)
        {
            _categoriaConsultaAppService = categoriaConsultaAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _categoriaConsultaAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: CategoriaConsulta
        public ActionResult Index()
        {
            try
            {
                IEnumerable<CategoriaConsultaViewModel> model = _categoriaConsultaAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: CategoriaConsulta/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                CategoriaConsultaViewModel model = _categoriaConsultaAppService.ObterPorId(id);
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

        // GET: CategoriaConsulta/Create
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

        // POST: CategoriaConsulta/Create
        [HttpPost]
        public ActionResult Create(CategoriaConsultaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                // TODO: Add insert logic here
                _categoriaConsultaAppService.Incluir(model);

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

        // GET: CategoriaConsulta/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                CategoriaConsultaViewModel model = _categoriaConsultaAppService.ObterPorId(id);
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

        // POST: CategoriaConsulta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoriaConsultaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                // TODO: Add update logic here
                _categoriaConsultaAppService.Atualizar(model);

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

        // GET: CategoriaConsulta/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                CategoriaConsultaViewModel model = _categoriaConsultaAppService.ObterPorId(id);
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

        // POST: CategoriaConsulta/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CategoriaConsultaViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _categoriaConsultaAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _categoriaConsultaAppService.Remover(model);

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
