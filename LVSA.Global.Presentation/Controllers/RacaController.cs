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
    public class RacaController : ControllerBase
    {
        private readonly IRacaCorAppService _racaCorAppService;

        public RacaController(IRacaCorAppService racaCorAppService)
        {
            _racaCorAppService = racaCorAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _racaCorAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: Raca
        public ActionResult Index()
        {
            try
            {
                IEnumerable<RacaCorViewModel> model = _racaCorAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Raca/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                RacaCorViewModel model = _racaCorAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
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

        // GET: Raca/Create
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

        // POST: Raca/Create
        [HttpPost]
        public ActionResult Create(RacaCorViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);
                
                _racaCorAppService.Incluir(model);

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

        // GET: Raca/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                RacaCorViewModel model = _racaCorAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
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

        // POST: Raca/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RacaCorViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);
                
                _racaCorAppService.Atualizar(model);

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

        // GET: Raca/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                RacaCorViewModel model = _racaCorAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
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

        // POST: Raca/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RacaCorViewModel model)
        {
            try
            {
                
                model = _racaCorAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _racaCorAppService.Remover(model);

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
