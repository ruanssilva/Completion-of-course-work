using LVSA.Base.Presentation.ViewModels;
using LVSA.Farm.Application.Interfaces;
using LVSA.Farm.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LVSA.Farm.Presentation.Controllers
{
    public class OrdenhaController : ControllerBase
    {
        private readonly IOrdenhaAppService _ordenhaAppService;
        private readonly IAnimalAppService _animalAppService;

        public OrdenhaController(IOrdenhaAppService ordenhaAppService, IAnimalAppService animalAppService)
        {
            _ordenhaAppService = ordenhaAppService;
            _animalAppService = animalAppService;
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Contexto.IsAuthentication())
            {
                _ordenhaAppService.SetSeguranca(Contexto.Seguranca);
                _animalAppService.SetSeguranca(Contexto.Seguranca);
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (Contexto.IsAuthentication())
            {
                ViewBag.AnimalSet = _animalAppService.Filtrar(f => f.TipoAnimal.Codigo == "VL").ToList();
            }
        }

        // GET: Ordenha
        public ActionResult Index()
        {
            try
            {
                var model = _ordenhaAppService.Filtrar(f => f.Horario.Month == DateTime.Now.Month).ToList();

                return View("Index", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Ordenha/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ordenha/Create
        public ActionResult Create(long? id)
        {
            try
            {
                ViewBag.AnimalId = id;

                return View("Create");
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Ordenha/Create
        [HttpPost]
        public ActionResult Create(OrdenhaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Create", model);

                _ordenhaAppService.Incluir(model);

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

        // GET: Ordenha/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ordenha/Edit/5
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

        // GET: Ordenha/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ordenha/Delete/5
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
