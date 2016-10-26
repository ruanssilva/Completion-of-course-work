

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
    public class MoradorController : ControllerBase
    {
        private readonly IMoradorAppService _moradorAppService;
        private readonly IMoradiaAppService _moradiaAppService;

        public MoradorController(IMoradorAppService moradorAppService, IMoradiaAppService moradiaAppService)
        {
            _moradorAppService = moradorAppService;
            _moradiaAppService = moradiaAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _moradorAppService.SetSeguranca(Contexto.Seguranca);
            _moradiaAppService.SetSeguranca(Contexto.Seguranca);
        }


        // GET: Morador
        public ActionResult Index()
        {
            try
            {
                IEnumerable<MoradorViewModel> model = _moradorAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Morador/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                MoradorViewModel model = _moradorAppService.ObterPorId(id);
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

        // GET: Morador/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.MoradiaSet = _moradiaAppService.Filtrar(f => f.Ativo);

                return View(new MoradorViewModel());
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Morador/Create
        [HttpPost]
        public ActionResult Create(MoradorViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.MoradiaSet = _moradiaAppService.Filtrar(f => f.Ativo);

                    return View(model);
                }
                // TODO: Add insert logic here
                _moradorAppService.Incluir(model);

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

        // GET: Morador/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                MoradorViewModel model = _moradorAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                ViewBag.MoradiaSet = _moradiaAppService.Filtrar(f => f.Ativo);

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Morador/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MoradorViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.MoradiaSet = _moradiaAppService.Filtrar(f => f.Ativo);

                    return View(model);
                }
                // TODO: Add update logic here
                _moradorAppService.Atualizar(model);

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

        // GET: Morador/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                MoradorViewModel model = _moradorAppService.ObterPorId(id);
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

        // POST: Morador/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MoradorViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _moradorAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _moradorAppService.Remover(model);

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
