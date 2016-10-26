

using LVSA.Base.Presentation.ViewModels;
using LVSA.Housing.Application.Interfaces;
using LVSA.Housing.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Housing.Presentation.Controllers
{
    public class MultaController : ControllerBase
    {
        private readonly IMultaAppService _multaAppService;

        public MultaController(IMultaAppService multaAppService)
        {
            _multaAppService = multaAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _multaAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: Multa
        public ActionResult Index()
        {
            try
            {
                IEnumerable<MultaViewModel> model = _multaAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Multa/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                MultaViewModel model = _multaAppService.ObterPorId(id);
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

        // GET: Multa/Create
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

        // POST: Multa/Create
        [HttpPost]
        public ActionResult Create(MultaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);
                // TODO: Add insert logic here
                _multaAppService.Incluir(model);

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

        // GET: Multa/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                MultaViewModel model = _multaAppService.ObterPorId(id);
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

        // POST: Multa/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MultaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);
                // TODO: Add update logic here
                _multaAppService.Atualizar(model);

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

        // GET: Multa/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                MultaViewModel model = _multaAppService.ObterPorId(id);
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

        // POST: Multa/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MultaViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _multaAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _multaAppService.Remover(model);

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
