
using LVSA.Base.Presentation.Controllers;

using LVSA.Base.Presentation.ViewModels;
using LVSA.Financial.Application.Interfaces;
using LVSA.Financial.Application.ViewModels;
using LVSA.Financial.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Financial.Presentation.Controllers
{
    public class LancamentoController : ControllerBase
    {
        private readonly ILancamentoAppService _lancamentoAppService;
        private readonly INFiscalAppService _nFiscalAppService;
        private readonly ICCustoAppService _cCustoAppService;

        public LancamentoController(ILancamentoAppService lancamentoAppService, INFiscalAppService nFiscalAppService, ICCustoAppService cCustoAppService)
        {
            _lancamentoAppService = lancamentoAppService;
            _nFiscalAppService = nFiscalAppService;
            _cCustoAppService = cCustoAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _nFiscalAppService.SetSeguranca(Contexto.Seguranca);
            _lancamentoAppService.SetSeguranca(Contexto.Seguranca);
            _cCustoAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: Lancamento
        public ActionResult Index()
        {
            try
            {
                ViewBag.CCustoSet = _cCustoAppService.Filtrar(f => f.Ativo);

                return View(new LancamentoAppViewModel { });
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        //
        // POST: Lancamento
        [HttpPost]
        public ActionResult Index(LancamentoAppViewModel model)
        {
            try
            {
                model.LancamentoSet = _lancamentoAppService.Filtrar(f =>
                    (model.CCustoId > 0 ? f.CCustoId == model.CCustoId : true) &&
                    (model.DataFiltroInicio != null ? f.DataLancamento >= model.DataFiltroInicio : true) &&
                    (model.DataFiltroFinal != null ? f.DataLancamento <= model.DataFiltroFinal : true) &&
                    (model.Entrada != null ? (model.Entrada == true ? (f.Valor > 0) : (f.Valor < 0)) : true)
                );

                ViewBag.CCustoSet = _cCustoAppService.Filtrar(f => f.Ativo);

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Lancamento/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                LancamentoViewModel model = _lancamentoAppService.ObterPorId(id);
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

        // GET: Lancamento/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.CCustoSet = _cCustoAppService.Filtrar(f => f.Ativo);
                ViewBag.NFiscalSet = _nFiscalAppService.Todos();

                return View(new LancamentoViewModel());
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Lancamento/Create
        [HttpPost]
        public ActionResult Create(LancamentoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.CCustoSet = _cCustoAppService.Filtrar(f => f.Ativo);
                    ViewBag.NFiscalSet = _nFiscalAppService.Todos();

                    return View(model);
                }
                // TODO: Add insert logic here
                _lancamentoAppService.Incluir(model);

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

        // GET: Lancamento/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                LancamentoViewModel model = _lancamentoAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                ViewBag.CCustoSet = _cCustoAppService.Filtrar(f => f.Ativo);
                ViewBag.NFiscalSet = _nFiscalAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Lancamento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LancamentoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.CCustoSet = _cCustoAppService.Filtrar(f => f.Ativo);
                    ViewBag.NFiscalSet = _nFiscalAppService.Todos();

                    return View(model);
                }
                // TODO: Add update logic here
                _lancamentoAppService.Atualizar(model);

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

        // GET: Lancamento/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                LancamentoViewModel model = _lancamentoAppService.ObterPorId(id);
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

        // POST: Lancamento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, LancamentoViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _lancamentoAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _lancamentoAppService.Remover(model);

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
