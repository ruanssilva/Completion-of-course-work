using LVSA.Farm.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Farm.Presentation.Controllers
{
    public class PrescricaoController : ControllerBase
    {
        private readonly IAnimalAppService _animalAppService;
        private readonly ITratamentoAppService _tratamentoAppService;
        private readonly IDiagnosticoAppService _diagnosticoAppService;
        private readonly IPrescricaoAppService _prescricaoAppService;

        public PrescricaoController(IDiagnosticoAppService diagnosticoAppService, IPrescricaoAppService prescricaoAppService, ITratamentoAppService tratamentoAppService, IAnimalAppService animalAppService)
        {
            _diagnosticoAppService = diagnosticoAppService;
            _tratamentoAppService = tratamentoAppService;
            _animalAppService = animalAppService;
            _prescricaoAppService = prescricaoAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Contexto.IsAuthentication())
            {
                _diagnosticoAppService.SetSeguranca(Contexto.Seguranca);
                _tratamentoAppService.SetSeguranca(Contexto.Seguranca);
                _tratamentoAppService.SetSeguranca(Contexto.Seguranca);
                _prescricaoAppService.SetSeguranca(Contexto.Seguranca);
            }
        }

        // GET: Prescricao
        public ActionResult Index()
        {
            try
            {
                var model = _prescricaoAppService.Todos();

                return View("Index", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Prescricao/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Prescricao/Create
        public ActionResult Create()
        {
            try
            {
                return View("Create");
            }
            catch(Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Prescricao/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

            }
            catch(Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");

        }

        // GET: Prescricao/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Prescricao/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Prescricao/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Prescricao/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
