using LVSA.Base.Application.Exceptions;
using LVSA.Base.Presentation.ViewModels;
using LVSA.Farm.Application.Interfaces;
using LVSA.Farm.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Farm.Presentation.Controllers
{
    public class LocalPesagemController : ControllerBase
    {
        private readonly ILocalPesagemAppService _localPesagemAppService;
        public LocalPesagemController(ILocalPesagemAppService LocalPesagemAppService)
        {
            _localPesagemAppService = LocalPesagemAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Contexto.IsAuthentication())
            {
                _localPesagemAppService.SetSeguranca(Contexto.Seguranca);
            }
        }

        // GET: LocalPesagem
        public ActionResult Index()
        {
            try
            {
                var model = _localPesagemAppService.Todos();
                return View("Index", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: LocalPesagem/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var model = _localPesagemAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if (model == null)
                    throw new NoRecordsFoundException("Registro não encontrado");

                return View("Details", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: LocalPesagem/Create
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

        // POST: LocalPesagem/Create
        [HttpPost]
        public ActionResult Create(LocalPesagemViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Create", model);

                _localPesagemAppService.Incluir(model);

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

        // GET: LocalPesagem/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var model = _localPesagemAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if (model == null)
                    throw new NoRecordsFoundException("Registro não encontrado");

                return View("Edit", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST: LocalPesagem/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LocalPesagemViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Edit", model);

                _localPesagemAppService.Atualizar(model);

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

        // GET: LocalPesagem/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var model = _localPesagemAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if (model == null)
                    throw new NoRecordsFoundException("Registro não encontrado");

                return View("Delete", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST: LocalPesagem/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, LocalPesagemViewModel model)
        {
            try
            {
                var _model = _localPesagemAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if (_model == null)
                    throw new NoRecordsFoundException("Registro não encontrado");

                _localPesagemAppService.Remover(model);

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
