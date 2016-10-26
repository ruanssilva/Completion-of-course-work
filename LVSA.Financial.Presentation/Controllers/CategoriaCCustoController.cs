
using LVSA.Base.Presentation.Controllers;

using LVSA.Base.Presentation.ViewModels;
using LVSA.Financial.Application.Interfaces;
using LVSA.Financial.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Financial.Presentation.Controllers
{
    public class CategoriaCCustoController : ControllerBase
    {
        private readonly ICategoriaCCustoAppService _categoriaCCustoAppService;

        public CategoriaCCustoController(ICategoriaCCustoAppService categoriaCCustoAppService)
        {
            _categoriaCCustoAppService = categoriaCCustoAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            

            _categoriaCCustoAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: CategoriaCCusto
        public ActionResult Index()
        {
            try
            {
                IEnumerable<CategoriaCCustoViewModel> model = _categoriaCCustoAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: CategoriaCCusto/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                CategoriaCCustoViewModel model = _categoriaCCustoAppService.ObterPorId(id);
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

        // GET: CategoriaCCusto/Create
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

        // POST: CategoriaCCusto/Create
        [HttpPost]
        public ActionResult Create(CategoriaCCustoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                // TODO: Add insert logic here
                _categoriaCCustoAppService.Incluir(model);

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

        // GET: CategoriaCCusto/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                CategoriaCCustoViewModel model = _categoriaCCustoAppService.ObterPorId(id);
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

        // POST: CategoriaCCusto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoriaCCustoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                // TODO: Add update logic here
                _categoriaCCustoAppService.Atualizar(model);

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

        // GET: CategoriaCCusto/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                CategoriaCCustoViewModel model = _categoriaCCustoAppService.ObterPorId(id);
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

        // POST: CategoriaCCusto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CategoriaCCustoViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _categoriaCCustoAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _categoriaCCustoAppService.Remover(model);

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
