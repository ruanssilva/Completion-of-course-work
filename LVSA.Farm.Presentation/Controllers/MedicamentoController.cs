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
    public class MedicamentoController : ControllerBase
    {
        private readonly IMedicamentoAppService _medicamentoAppService;
        private readonly ITipoMedicamentoAppService _tipoMedicamentoAppService;
        public MedicamentoController(IMedicamentoAppService MedicamentoAppService, ITipoMedicamentoAppService tipoMedicamentoAppService)
        {
            _medicamentoAppService = MedicamentoAppService;
            _tipoMedicamentoAppService = tipoMedicamentoAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Contexto.IsAuthentication())
            {
                _medicamentoAppService.SetSeguranca(Contexto.Seguranca);
            }
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            ViewBag.TipoMedicamentoSet = _tipoMedicamentoAppService.Filtrar(f => f.Ativo);
        }

        // GET: Medicamento
        public ActionResult Index()
        {
            try
            {
                var model = _medicamentoAppService.Todos();
                return View("Index", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Medicamento/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var model = _medicamentoAppService.Filtrar(f => f.Id == id).SingleOrDefault();
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

        // GET: Medicamento/Create
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

        // POST: Medicamento/Create
        [HttpPost]
        public ActionResult Create(MedicamentoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Create", model);

                _medicamentoAppService.Incluir(model);

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

        // GET: Medicamento/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var model = _medicamentoAppService.Filtrar(f => f.Id == id).SingleOrDefault();
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

        // POST: Medicamento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MedicamentoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Edit", model);

                _medicamentoAppService.Atualizar(model);

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

        // GET: Medicamento/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var model = _medicamentoAppService.Filtrar(f => f.Id == id).SingleOrDefault();
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

        // POST: Medicamento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MedicamentoViewModel model)
        {
            try
            {
                var _model = _medicamentoAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if (_model == null)
                    throw new NoRecordsFoundException("Registro não encontrado");

                _medicamentoAppService.Remover(model);

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
