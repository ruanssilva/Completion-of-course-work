
using LVSA.Base.Presentation.Controllers;

using LVSA.Base.Presentation.ViewModels;
using LVSA.Financial.Application.Interfaces;
using LVSA.Financial.Application.ViewModels;
using LVSA.Global.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Financial.Presentation.Controllers
{
    public class NFiscalController : ControllerBase
    {
        private readonly INFiscalAppService _nFiscalAppService;
        private readonly IPessoaJuridicaAppService _pessoaJuridicaAppService;

        public NFiscalController(INFiscalAppService nFiscalAppService, IPessoaJuridicaAppService pessoaJuridicaAppService)
        {
            _nFiscalAppService = nFiscalAppService;
            _pessoaJuridicaAppService = pessoaJuridicaAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _nFiscalAppService.SetSeguranca(Contexto.Seguranca);
            _pessoaJuridicaAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: NFiscal
        public ActionResult Index()
        {
            try
            {
                IEnumerable<NFiscalViewModel> model = _nFiscalAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: NFiscal/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                NFiscalViewModel model = _nFiscalAppService.ObterPorId(id);
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

        // GET: NFiscal/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.EmpresaSet = _pessoaJuridicaAppService.Todos();

                return View(new NFiscalViewModel { DataEmissao = DateTime.Now });
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: NFiscal/Create
        [HttpPost]
        public ActionResult Create(NFiscalViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.EmpresaSet = _pessoaJuridicaAppService.Todos();

                    return View(model);
                }

                // TODO: Add insert logic here
                _nFiscalAppService.Incluir(model);

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

        // GET: NFiscal/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                NFiscalViewModel model = _nFiscalAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                ViewBag.EmpresaSet = _pessoaJuridicaAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: NFiscal/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, NFiscalViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.EmpresaSet = _pessoaJuridicaAppService.Todos();

                    return View(model);
                }

                // TODO: Add update logic here
                _nFiscalAppService.Atualizar(model);

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

        // GET: NFiscal/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                NFiscalViewModel model = _nFiscalAppService.ObterPorId(id);
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

        // POST: NFiscal/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, NFiscalViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _nFiscalAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _nFiscalAppService.Remover(model);

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
