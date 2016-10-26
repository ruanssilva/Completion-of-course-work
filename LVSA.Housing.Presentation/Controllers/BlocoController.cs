

using LVSA.Base.Presentation.ViewModels;
using LVSA.Housing.Application.Interfaces;
using LVSA.Housing.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Housing.Presentation.Controllers
{
    public class BlocoController : ControllerBase
    {
        private readonly IBlocoAppService _blocoAppService;
        private readonly ISindicoAppService _sindicoAppService;

        public BlocoController(IBlocoAppService blocoAppService, ISindicoAppService sindicoAppService)
        {
            _blocoAppService = blocoAppService;
            _sindicoAppService = sindicoAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _blocoAppService.SetSeguranca(Contexto.Seguranca);
            _sindicoAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: Bloco
        public ActionResult Index()
        {
            try
            {
                IEnumerable<BlocoViewModel> model = _blocoAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Bloco/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                BlocoViewModel model = _blocoAppService.ObterPorId(id);
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

        // GET: Bloco/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.SindicoSet = _sindicoAppService.Filtrar(f => f.Ativo);

                return View(new BlocoViewModel());
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Bloco/Create
        [HttpPost]
        public ActionResult Create(BlocoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.SindicoSet = _sindicoAppService.Filtrar(f => f.Ativo);

                    return View(model);
                }
                // TODO: Add insert logic here
                _blocoAppService.Incluir(model);

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

        // GET: Bloco/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                BlocoViewModel model = _blocoAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                ViewBag.SindicoSet = _sindicoAppService.Filtrar(f => f.Ativo);

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Bloco/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BlocoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.SindicoSet = _sindicoAppService.Filtrar(f => f.Ativo);

                    return View(model);
                }
                // TODO: Add update logic here
                _blocoAppService.Atualizar(model);

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

        // GET: Bloco/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                BlocoViewModel model = _blocoAppService.ObterPorId(id);
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

        // POST: Bloco/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BlocoViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _blocoAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _blocoAppService.Remover(model);

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
