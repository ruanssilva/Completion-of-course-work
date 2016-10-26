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
    public class TipoMedicamentoController : ControllerBase
    {
        private readonly ITipoMedicamentoAppService _tipoMedicamentoAppService;
        public TipoMedicamentoController(ITipoMedicamentoAppService TipoMedicamentoAppService)
        {
            _tipoMedicamentoAppService = TipoMedicamentoAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Contexto.IsAuthentication())
            {
                _tipoMedicamentoAppService.SetSeguranca(Contexto.Seguranca);
            }
        }

        // GET: TipoMedicamento
        public ActionResult Index()
        {
            try
            {
                var model = _tipoMedicamentoAppService.Todos();
                return View("Index", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: TipoMedicamento/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var model = _tipoMedicamentoAppService.Filtrar(f => f.Id == id).SingleOrDefault();
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

        // GET: TipoMedicamento/Create
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

        // POST: TipoMedicamento/Create
        [HttpPost]
        public ActionResult Create(TipoMedicamentoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Create", model);

                _tipoMedicamentoAppService.Incluir(model);

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

        // GET: TipoMedicamento/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var model = _tipoMedicamentoAppService.Filtrar(f => f.Id == id).SingleOrDefault();
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

        // POST: TipoMedicamento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TipoMedicamentoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Edit", model);

                _tipoMedicamentoAppService.Atualizar(model);

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

        // GET: TipoMedicamento/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var model = _tipoMedicamentoAppService.Filtrar(f => f.Id == id).SingleOrDefault();
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

        // POST: TipoMedicamento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TipoMedicamentoViewModel model)
        {
            try
            {
                var _model = _tipoMedicamentoAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if (_model == null)
                    throw new NoRecordsFoundException("Registro não encontrado");

                _tipoMedicamentoAppService.Remover(model);

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
