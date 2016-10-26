
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
    public class CCustoController : ControllerBase
    {
        private readonly ICCustoAppService _cCustoAppService;
        private readonly ICategoriaCCustoAppService _categoriaCCustoAppService;

        public CCustoController(ICCustoAppService cCustoAppService, ICategoriaCCustoAppService categoriaCCustoAppService)
        {
            _categoriaCCustoAppService = categoriaCCustoAppService;
            _cCustoAppService = cCustoAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if(Contexto.IsAuthentication())
            {
                _cCustoAppService.SetSeguranca(Contexto.Seguranca);
                _categoriaCCustoAppService.SetSeguranca(Contexto.Seguranca);
            }
           
        }

        // GET: CCusto
        public ActionResult Index()
        {
            try
            {
                IEnumerable<CCustoViewModel> model = _cCustoAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: CCusto/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                CCustoViewModel model = _cCustoAppService.ObterPorId(id);
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

        // GET: CCusto/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.CategoriaCCustoSet = _categoriaCCustoAppService.Filtrar(f => f.Ativo);

                return View(new CCustoViewModel());
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: CCusto/Create
        [HttpPost]
        public ActionResult Create(CCustoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.CategoriaCCustoSet = _categoriaCCustoAppService.Filtrar(f => f.Ativo);

                    return View(model);
                }
                // TODO: Add insert logic here
                _cCustoAppService.Incluir(model);

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

        // GET: CCusto/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                CCustoViewModel model = _cCustoAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                ViewBag.CategoriaCCustoSet = _categoriaCCustoAppService.Filtrar(f => f.Ativo);

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: CCusto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CCustoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.CategoriaCCustoSet = _categoriaCCustoAppService.Filtrar(f => f.Ativo);

                    return View(model);
                }
                // TODO: Add update logic here
                _cCustoAppService.Atualizar(model);

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

        // GET: CCusto/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                CCustoViewModel model = _cCustoAppService.ObterPorId(id);
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

        // POST: CCusto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CCustoViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _cCustoAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _cCustoAppService.Remover(model);

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
