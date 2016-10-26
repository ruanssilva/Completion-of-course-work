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
    public class FilialController : ControllerBase
    {
        private readonly IColigadaAppService _coligadaAppService;
        private readonly IFilialAppService _filialAppService;

        public FilialController(IColigadaAppService coligadaAppService, IFilialAppService filialAppService)
        {
            _coligadaAppService = coligadaAppService;
            _filialAppService = filialAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            ViewBag.ColigadaSet = _coligadaAppService.Todos();
        }

        // GET: Coligada
        public ActionResult Index()
        {
            try
            {
                var coligadaset = _filialAppService.Todos();

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
                var coligada = _filialAppService.Filtrar(f => f.Id == id).SingleOrDefault();

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
        public ActionResult Create(FilialViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                _filialAppService.Incluir(model);

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
                var coligada = _filialAppService.Filtrar(f => f.Id == id).SingleOrDefault();

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
        public ActionResult Edit(int id, FilialViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                _filialAppService.Atualizar(model);

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
                var coligada = _filialAppService.Filtrar(f => f.Id == id).SingleOrDefault();

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
        public ActionResult Delete(int id, FilialViewModel model)
        {
            try
            {
                var coligada = _filialAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if (coligada != null)
                {
                    _filialAppService.Remover(model);

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
