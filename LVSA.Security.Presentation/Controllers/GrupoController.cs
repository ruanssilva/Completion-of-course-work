using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LVSA.Base.Application.Exceptions;
using LVSA.Base.Presentation.ViewModels;
using LVSA.Security.Application.Interfaces;
using LVSA.Security.Application.Models;
using LVSA.Security.Application.ViewModels;
using LVSA.Security.Presentation.ViewModels;

namespace LVSA.Security.Presentation.Controllers
{
    public class GrupoController : FiltroController
    {
        private readonly IGrupoAppService _grupoAppService;

        public GrupoController(IGrupoAppService grupoAppService)
        {
            _grupoAppService = grupoAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _grupoAppService.SetSeguranca(Contexto.Seguranca, false);

            if (FFilialId != null)
            {
                ViewBag.AplicacaoSet = null;
                var aplicacoes = _contextoAppService.Acessos(f => f.FilialId == FFilialId).GroupBy(g => g.Id).Select(s => s.First());
                if (aplicacoes.Count() > 0)
                {
                    if (aplicacoes.Count() == 1)
                        FAplicacaoId = aplicacoes.Single().Id;
                    else if (FAplicacaoId == null)
                        ModelState.AddModelError("AplicacaoId", "Informe a aplicação para o filtro");

                    ViewBag.AplicacaoSet = aplicacoes;
                }
                else
                    ModelState.AddModelError("AplicacaoId", "Não existe aplicação concedida para a filial.");
            }

            if (FFilialId != null && FAplicacaoId != null)
            {
                var aplicacao = _aplicacaoAppService.ObterPorId((int)FAplicacaoId);
                ViewBag.GrupoSet = aplicacao.GrupoSet.Where(w => w.FilialId == FFilialId);
            }
            else
                ViewBag.GrupoSet = null;

            ViewBag.FilialId = FFilialId;
            ViewBag.AplicacaoId = FAplicacaoId;
        }

        // GET: Grupo
        public ActionResult Index(char id = 'L')
        {
            try
            {
                if (id == 'L')
                {
                    ModelState.Clear();

                    FFilialId = null;
                    FAplicacaoId = null;

                    ViewBag.FilialId = FFilialId;
                    ViewBag.AplicacaoId = FAplicacaoId;

                    ViewBag.GrupoSet = null;
                    ViewBag.AplicacaoSet = null;


                }

                return View();
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST: Grupo/Index
        [HttpPost]
        public ActionResult Index(GrupoViewModel model)
        {
            try
            {
                if (ViewBag.AplicacaoSet != null && FAplicacaoId == null)
                    if (((IEnumerable<AplicacaoViewModel>)ViewBag.AplicacaoSet).Count() > 1)
                        ModelState.AddModelError("AplicacaoId", "Informe a aplicação para o filtro");
                    else
                        ModelState.AddModelError("AplicacaoId", "Não existe aplicação concedida para a filial.");

                return View("Index");
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Grupo/Details/5
        public ActionResult Details(long id)
        {
            try
            {
                var model = _grupoAppService.ObterPorId(id);
                if (model == null)
                    throw new NoRecordsFoundException("Grupo não encontrado");


                ViewBag.Details = true;

                return View("Index", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Action(GrupoViewModel model)
        {
            try
            {



                if (model.Id > 0)
                    return Edit(model);
                else
                    return Create(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: Grupo/Create
        public ActionResult Create()
        {
            try
            {
                return View("Index", new GrupoViewModel { });
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Grupo/Create
        [HttpPost]
        public ActionResult Create(GrupoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Index", model);

                model.ColigadaId = Contexto.Seguranca.FilialSet.Where(w => w.Id == FFilialId).Select(s => s.Coligada.Id).Single();
                model.FilialId = FFilialId;

                _grupoAppService.Incluir(model);

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

            return RedirectToAction("Index", new { id = 'M' });
        }

        // GET: Grupo/Edit/5
        public ActionResult Edit(long id)
        {
            try
            {
                var model = _grupoAppService.ObterPorId(id);
                if (model == null)
                    throw new NoRecordsFoundException("Grupo não encontrado");

                return View("Index", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Grupo/Edit/5
        [HttpPost]
        public ActionResult Edit(GrupoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Index", model);

                model.ColigadaId = Contexto.Seguranca.FilialSet.Where(w => w.Id == FFilialId).Select(s => s.Coligada.Id).Single();
                model.FilialId = FFilialId;

                _grupoAppService.Atualizar(model);

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

            return RedirectToAction("Index", new { id = 'M' });
        }

        // GET: Grupo/Delete/5
        public ActionResult Delete(long id)
        {
            try
            {
                var model = _grupoAppService.ObterPorId(id);
                if (model == null)
                    throw new NoRecordsFoundException("Grupo não encontrado");


                ViewBag.Delete = true;

                return View("Index", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Grupo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, GrupoViewModel model)
        {
            try
            {
                var grupo = _grupoAppService.ObterPorId(id);
                if (grupo != null)
                {
                    _grupoAppService.Remover(grupo);

                    Gritters.Add(new GritterViewModel
                    {
                        Tittle = "Sucesso!",
                        Message = "Operação realizada com sucesso.",
                        Style = GritterStyle.Success,
                    });
                }
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", new { id = 'M' });
        }



    }
}
