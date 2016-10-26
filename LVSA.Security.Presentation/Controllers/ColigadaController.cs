using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LVSA.Base.Application.Exceptions;
using LVSA.Base.Presentation.ViewModels;
using LVSA.Security.Application.Interfaces;
using LVSA.Security.Application.ViewModels;

namespace LVSA.Security.Presentation.Controllers
{
    public class ColigadaController : ControllerBase
    {
        private readonly IColigadaAppService _coligadaAppService;

        public ColigadaController(IColigadaAppService coligadaAppService)
        {
            _coligadaAppService = coligadaAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _coligadaAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: Coligada
        public ActionResult Index()
        {
            try
            {
                var coligadaset = _coligadaAppService.Todos();

                return View("Index", coligadaset);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Coligada/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var coligada = _coligadaAppService.Filtrar(f => f.Id == id).SingleOrDefault();

                if (coligada == null)
                    throw new NoRecordsFoundException("Tipo recurso não encontrado");

                return View("Details", coligada);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: Coligada/Create
        public ActionResult Create()
        {
            try
            {
                return View("Create");
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Coligada/Create
        [HttpPost]
        public ActionResult Create(ColigadaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                _coligadaAppService.Incluir(model);

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

        // GET: Coligada/Edit/5
        public ActionResult Edit(short id)
        {
            try
            {
                var coligada = _coligadaAppService.Filtrar(f => f.Id == id).SingleOrDefault();

                if (coligada == null)
                    throw new NoRecordsFoundException("Tipo recurso não encontrado");

                return View("Edit", coligada);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Coligada/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ColigadaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                _coligadaAppService.Atualizar(model);

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

        // GET: Coligada/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var coligada = _coligadaAppService.Filtrar(f => f.Id == id).SingleOrDefault();

                if (coligada == null)
                    throw new NoRecordsFoundException("Tipo recurso não encontrado");

                return View("Delete", coligada);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Coligada/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ColigadaViewModel model)
        {
            try
            {
                var coligada = _coligadaAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if (coligada != null)
                {
                    _coligadaAppService.Remover(model);

                    Gritters.Add(new GritterViewModel
                    {
                        Tittle = "Sucesso!",
                        Message = "Operação realizada com sucesso.",
                        Style = GritterStyle.Success,
                    });
                }
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }
    }
}
