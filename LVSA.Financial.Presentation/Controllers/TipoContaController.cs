using LVSA.Base.Presentation.ViewModels;
using LVSA.Financial.Application.Interfaces;
using LVSA.Financial.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Financial.Presentation.Controllers
{
    public class TipoContaController : ControllerBase
    {
        private readonly ITipoContaAppService _tipoContaAppService;

        public TipoContaController(ITipoContaAppService TipoContaAppService)
        {
            _tipoContaAppService = TipoContaAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);



            _tipoContaAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: TipoConta
        public ActionResult Index()
        {
            try
            {
                IEnumerable<TipoContaViewModel> model = _tipoContaAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: TipoConta/Details/5
        public ActionResult Details(short id)
        {
            try
            {
                TipoContaViewModel model = _tipoContaAppService.ObterPorId(id);
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

        // GET: TipoConta/Create
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

        // POST: TipoConta/Create
        [HttpPost]
        public ActionResult Create(TipoContaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                // TODO: Add insert logic here
                _tipoContaAppService.Incluir(model);

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

        // GET: TipoConta/Edit/5
        public ActionResult Edit(short id)
        {
            try
            {
                TipoContaViewModel model = _tipoContaAppService.ObterPorId(id);
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

        // POST: TipoConta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TipoContaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                // TODO: Add update logic here
                _tipoContaAppService.Atualizar(model);

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

        // GET: TipoConta/Delete/5
        public ActionResult Delete(short id)
        {
            try
            {
                TipoContaViewModel model = _tipoContaAppService.ObterPorId(id);
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

        // POST: TipoConta/Delete/5
        [HttpPost]
        public ActionResult Delete(short id, TipoContaViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _tipoContaAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _tipoContaAppService.Remover(model);

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
