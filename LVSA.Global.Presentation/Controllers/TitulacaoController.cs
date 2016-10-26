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
    public class TitulacaoController : ControllerBase
    {
        private readonly ITitulacaoAppService _titulacaoAppService;

        public TitulacaoController(ITitulacaoAppService titulacaoAppService)
        {
            _titulacaoAppService = titulacaoAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _titulacaoAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: Titulacao
        public ActionResult Index()
        {
            try
            {
                IEnumerable<TitulacaoViewModel> model = _titulacaoAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Titulacao/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                TitulacaoViewModel model = _titulacaoAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
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

        // GET: Titulacao/Create
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

        // POST: Titulacao/Create
        [HttpPost]
        public ActionResult Create(TitulacaoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);
                // TODO: Add insert logic here
                _titulacaoAppService.Incluir(model);

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

        // GET: Titulacao/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                TitulacaoViewModel model = _titulacaoAppService.Filtrar(f => f.Id == id).SingleOrDefault();
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

        // POST: Titulacao/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TitulacaoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);
                // TODO: Add update logic here
                _titulacaoAppService.Atualizar(model);

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

        // GET: Titulacao/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                TitulacaoViewModel model = _titulacaoAppService.Filtrar(f => f.Id == id).SingleOrDefault();
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

        // POST: Titulacao/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TitulacaoViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _titulacaoAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _titulacaoAppService.Remover(model);

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