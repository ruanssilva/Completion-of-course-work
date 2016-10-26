using LVSA.Base.Presentation.ViewModels;
using LVSA.Global.Application.Interfaces;
using LVSA.Global.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace LVSA.Global.Presentation.Controllers
{
    public class CidadeController : ControllerBase
    {
        private readonly IEstadoAppService _estadoAppService;
        private readonly ICidadeAppService _cidadeAppService;

        public CidadeController(IEstadoAppService estadoAppService, ICidadeAppService cidadeAppService)
        {
            _estadoAppService = estadoAppService;
            _cidadeAppService = cidadeAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            ViewBag.EstadoSet = _estadoAppService.Todos();

            _estadoAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: Cidade
        public ActionResult Index()
        {
            try
            {
                IEnumerable<CidadeViewModel> model = _cidadeAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Cidade/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                CidadeViewModel model = _cidadeAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
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

        // GET: Cidade/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.EstadoSet = _estadoAppService.Todos();

                return View(new CidadeViewModel());
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Cidade/Create
        [HttpPost]
        public ActionResult Create(CidadeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.EstadoSet = _estadoAppService.Todos();

                    return View(model);
                }
                // TODO: Add insert logic here
                _cidadeAppService.Incluir(model);

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

        // GET: Cidade/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                CidadeViewModel model = _cidadeAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
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

        // POST: Cidade/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CidadeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(model);
                }
                // TODO: Add update logic here
                _cidadeAppService.Atualizar(model);

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

        // GET: Cidade/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                CidadeViewModel model = _cidadeAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
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

        // POST: Cidade/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CidadeViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _cidadeAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _cidadeAppService.Remover(model);

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
