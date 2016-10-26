using LVSA.Base.Application.Exceptions;
using LVSA.Base.Presentation.ViewModels;
using LVSA.Farm.Application.Interfaces;
using LVSA.Farm.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Farm.Presentation.Controllers
{
    public class TratamentoController : ControllerBase
    {
        private readonly ITratamentoAppService _tratamentoAppService;
        private readonly IDoencaAppService _doencaAppService;
        private readonly IMedicamentoAppService _medicamentoAppService;
        public TratamentoController(ITratamentoAppService TratamentoAppService, IDoencaAppService doencaAppService, IMedicamentoAppService medicamentoAppService)
        {
            _doencaAppService = doencaAppService;
            _tratamentoAppService = TratamentoAppService;
            _medicamentoAppService = medicamentoAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Contexto.IsAuthentication())
            {
                _tratamentoAppService.SetSeguranca(Contexto.Seguranca);
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            ViewBag.DoencaSet = _doencaAppService.Filtrar(f => f.Ativo);
            ViewBag.MedicamentoSet = _medicamentoAppService.Filtrar(f => f.Ativo);
        }

        // GET: Tratamento
        public ActionResult Index()
        {
            try
            {
                var model = _tratamentoAppService.Todos();
                return View("Index", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Tratamento/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var model = _tratamentoAppService.Filtrar(f => f.Id == id).SingleOrDefault();
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

        // GET: Tratamento/Create
        public ActionResult Create()
        {
            try
            {
                var model = new TratamentoViewModel() { DosagemSet = new List<DosagemViewModel> { new DosagemViewModel { } } };

                return View("Create", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Tratamento/Create
        [HttpPost]
        public ActionResult Create(TratamentoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Create", model);

                _tratamentoAppService.Incluir(model);

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

        // GET: Tratamento/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var model = _tratamentoAppService.Filtrar(f => f.Id == id).SingleOrDefault();
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

        // POST: Tratamento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TratamentoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Edit", model);


                _tratamentoAppService.Atualizar(model);

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

        // GET: Tratamento/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var model = _tratamentoAppService.Filtrar(f => f.Id == id).SingleOrDefault();
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

        // POST: Tratamento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TratamentoViewModel model)
        {
            try
            {
                var _model = _tratamentoAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if (_model == null)
                    throw new NoRecordsFoundException("Registro não encontrado");

                _tratamentoAppService.Remover(model);

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

        [HttpPost]
        public ActionResult Dosagem(TratamentoViewModel model, bool remover = false, bool adicionar = false)
        {
            try
            {
                var lista = model.DosagemSet == null ? new List<DosagemViewModel> { } : model.DosagemSet.ToList();

                if (adicionar)
                    lista.Add(new DosagemViewModel { });

                if (remover)
                    lista.Remove(model.DosagemSet.Last());

                model.DosagemSet = lista;

                ModelState.Clear();
                                
                return View("PartialView/Dosagem", model);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }


        public ActionResult Iniciar()
        {
            try
            {

            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Iniciar(PrescricaoViewModel model)
        {
            try
            {

            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }
    }
}
