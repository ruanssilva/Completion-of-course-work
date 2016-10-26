using System.Linq;
using LVSA.Base.Presentation.ViewModels;
using LVSA.Global.Application.Interfaces;
using LVSA.Global.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LVSA.Global.Presentation.Controllers
{
    public class BairroController : ControllerBase
    {
        private readonly IBairroAppService _bairroAppService;
        private readonly ICidadeAppService _cidadeAppService;

        public BairroController(IBairroAppService bairroAppService, ICidadeAppService cidadeAppService)
        {
            _bairroAppService = bairroAppService;
            _cidadeAppService = cidadeAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            ViewBag.CidadeSet = _cidadeAppService.Todos();

            _bairroAppService.SetSeguranca(Contexto.Seguranca);
            _cidadeAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: Bairro
        public ActionResult Index()
        {
            try
            {
                IEnumerable<BairroViewModel> model = _bairroAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Bairro/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                BairroViewModel model = _bairroAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
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

        // GET: Bairro/Create
        public ActionResult Create()
        {
            try
            {
                
                
                return View(new BairroViewModel());
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Bairro/Create
        [HttpPost]
        public ActionResult Create(BairroViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(model);
                }
                // TODO: Add insert logic here
                _bairroAppService.Incluir(model);

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

        // GET: Bairro/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                BairroViewModel model = _bairroAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
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

        // POST: Bairro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BairroViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(model);
                }
                // TODO: Add update logic here
                _bairroAppService.Atualizar(model);

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

        // GET: Bairro/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                BairroViewModel model = _bairroAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
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

        // POST: Bairro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BairroViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _bairroAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _bairroAppService.Remover(model);

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
