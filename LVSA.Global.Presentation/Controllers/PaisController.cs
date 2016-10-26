
using LVSA.Base.Presentation.ViewModels;
using LVSA.Global.Application.Interfaces;
using LVSA.Global.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Global.Presentation.Controllers
{
    public class PaisController : ControllerBase
    {
        private readonly IPaisAppService _paisAppService;

        public PaisController(IPaisAppService paisAppService)
        {
            _paisAppService = paisAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _paisAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: Pais
        public ActionResult Index()
        {
            try
            {
                IEnumerable<PaisViewModel> model = _paisAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Pais/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                PaisViewModel model = _paisAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
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

        // GET: Pais/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Pais/Create
        [HttpPost]
        public ActionResult Create(PaisViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);
                
                _paisAppService.Incluir(model);

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

        // GET: Pais/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                PaisViewModel model = _paisAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
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

        // POST: Pais/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PaisViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);
                
                _paisAppService.Atualizar(model);

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

        // GET: Pais/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                PaisViewModel model = _paisAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
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

        // POST: Pais/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PaisViewModel model)
        {
            try
            {
                
                model = _paisAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _paisAppService.Remover(model);

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
