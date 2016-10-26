

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
    public class CategoriaInstrucaoController : ControllerBase
    {
        private readonly ICategoriaInstrucaoAppService _categoriaInstrucaoAppService;

        public CategoriaInstrucaoController(ICategoriaInstrucaoAppService categoriaInstrucaoAppService)
        {
            _categoriaInstrucaoAppService = categoriaInstrucaoAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _categoriaInstrucaoAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: CategoriaInstrucao
        public ActionResult Index()
        {
            try
            {
                IEnumerable<CategoriaInstrucaoViewModel> model = _categoriaInstrucaoAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: CategoriaInstrucao/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                CategoriaInstrucaoViewModel model = _categoriaInstrucaoAppService.ObterPorId(id);
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

        // GET: CategoriaInstrucao/Create
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

        // POST: CategoriaInstrucao/Create
        [HttpPost]
        public ActionResult Create(CategoriaInstrucaoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                // TODO: Add insert logic here
                _categoriaInstrucaoAppService.Incluir(model);

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

        // GET: CategoriaInstrucao/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                CategoriaInstrucaoViewModel model = _categoriaInstrucaoAppService.ObterPorId(id);
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

        // POST: CategoriaInstrucao/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoriaInstrucaoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                // TODO: Add update logic here
                _categoriaInstrucaoAppService.Atualizar(model);

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

        // GET: CategoriaInstrucao/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                CategoriaInstrucaoViewModel model = _categoriaInstrucaoAppService.ObterPorId(id);
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

        // POST: CategoriaInstrucao/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CategoriaInstrucaoViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _categoriaInstrucaoAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _categoriaInstrucaoAppService.Remover(model);

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
