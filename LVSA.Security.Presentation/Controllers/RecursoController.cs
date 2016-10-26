using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LVSA.Base.Application.Exceptions;
using LVSA.Base.Presentation.ViewModels;
using LVSA.Security.Application.Interfaces;
using LVSA.Security.Application.ViewModels;
using LVSA.Security.Presentation.ViewModels;

namespace LVSA.Security.Presentation.Controllers
{
    public class RecursoController : ControllerBase
    {
        private readonly IAplicacaoAppService _aplicacaoAppService;
        private readonly IRecursoAppService _recursoAppService;
        private readonly ITipoRecursoAppService _tipoRecursoAppService;

        public RecursoController(IAplicacaoAppService aplicacaoAppService, IRecursoAppService recursoAppService, ITipoRecursoAppService tipoRecursoAppService)
        {
            _aplicacaoAppService = aplicacaoAppService;
            _recursoAppService = recursoAppService;
            _tipoRecursoAppService = tipoRecursoAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _aplicacaoAppService.SetSeguranca(Contexto.Seguranca);
            _recursoAppService.SetSeguranca(Contexto.Seguranca);
            _tipoRecursoAppService.SetSeguranca(Contexto.Seguranca);

            ViewBag.TipoRecursoSet = _tipoRecursoAppService.Filtrar(f => f.Ativo);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            AddShortcut("Ir para permissões", Url.Action("Grupo", "Permissao"), "fa fa-shield");
        }

        // GET: Recurso
        public ActionResult Index(int idaplicacao)
        {
            try
            {
                var aplicacao = _aplicacaoAppService.ObterPorId(idaplicacao);
                if (aplicacao == null)
                    throw new NoRecordsFoundException("Aplicação não encontrada");


                RecursosViewModel model = new RecursosViewModel
                {
                    Aplicacao = aplicacao,
                    RecursoSet = aplicacao.RecursoSet
                };

                return View("Index", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");

        }

        // GET: Recurso/Details/5
        public ActionResult Details(int idaplicacao, long? idrecurso)
        {
            try
            {
                var aplicacao = _aplicacaoAppService.ObterPorId(idaplicacao);
                if (aplicacao == null)
                    throw new NoRecordsFoundException("Aplicação não encontrada");

                var recurso = idrecurso != null ? _recursoAppService.Filtrar(f => f.AplicacaoId == aplicacao.Id && f.Id == idrecurso).SingleOrDefault() : null;
                if (idrecurso != null && recurso == null)
                    throw new NoRecordsFoundException("Recurso não encontrado");

                ViewBag.Details = true;

                RecursosViewModel model = new RecursosViewModel
                {
                    Aplicacao = aplicacao,
                    RecursoSet = aplicacao.RecursoSet,
                    Recurso = recurso
                };

                return View("Index", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", new { idaplicacao = idaplicacao });
        }

        // POST: Recurso/Action
        [HttpPost]
        public ActionResult Action(RecursosViewModel model)
        {
            try
            {
                if (model.Recurso.Id > 0)
                    return Edit(model);
                else
                    return Create(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", new { idaplicacao = model.Recurso.AplicacaoId });
        }

        // GET: Recurso/Create
        public ActionResult Create(int idaplicacao, long? idrecurso)
        {
            try
            {
                var aplicacao = _aplicacaoAppService.ObterPorId(idaplicacao);
                if (aplicacao == null)
                    throw new NoRecordsFoundException("Aplicação não encontrado");

                var recurso = idrecurso != null ? _recursoAppService.Filtrar(f => f.AplicacaoId == aplicacao.Id && f.Id == idrecurso).SingleOrDefault() : null;
                if (idrecurso != null && recurso == null)
                    throw new NoRecordsFoundException("Recurso não encontrado");

                RecursosViewModel model = new RecursosViewModel
                {
                    Aplicacao = aplicacao,
                    RecursoSet = aplicacao.RecursoSet,
                    Recurso = new RecursoViewModel
                    {
                        AplicacaoId = aplicacao.Id,
                        Aplicacao = aplicacao,
                        Ativo = true,
                        RecursoPaiId = recurso != null ? recurso.Id : (long?)null,
                        RecursoPai = recurso,
                        Controller = recurso != null ? recurso.Controller : string.Empty
                    }
                };

                return View("Index", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", new { idaplicacao = idaplicacao });
        }

        // POST: Recurso/Create
        [HttpPost]
        public ActionResult Create(RecursosViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    model.Aplicacao = _aplicacaoAppService.ObterPorId(model.Recurso.AplicacaoId);
                    model.RecursoSet = model.Aplicacao.RecursoSet.Where(w => w.RecursoPaiId == null);

                    return View("Index", model);
                }

                _recursoAppService.Incluir(model.Recurso);

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

            return RedirectToAction("Index", new { idaplicacao = model.Recurso.AplicacaoId });
        }

        // GET: Recurso/Edit/5
        public ActionResult Edit(int idaplicacao, long? idrecurso)
        {
            try
            {
                var aplicacao = _aplicacaoAppService.ObterPorId(idaplicacao);
                if (aplicacao == null)
                    throw new NoRecordsFoundException("Aplicação não encontrado");

                var recurso = idrecurso != null ? _recursoAppService.Filtrar(f => f.AplicacaoId == aplicacao.Id && f.Id == idrecurso).SingleOrDefault() : null;
                if (idrecurso != null && recurso == null)
                    throw new NoRecordsFoundException("Recurso não encontrado");

                RecursosViewModel model = new RecursosViewModel
                {
                    Aplicacao = aplicacao,
                    RecursoSet = aplicacao.RecursoSet,
                    Recurso = recurso
                };

                return View("Index", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", new { idaplicacao = idaplicacao });
        }

        // POST: Recurso/Edit/5
        [HttpPost]
        public ActionResult Edit(RecursosViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    model.Aplicacao = _aplicacaoAppService.ObterPorId(model.Recurso.AplicacaoId);
                    model.RecursoSet = model.Aplicacao.RecursoSet;

                    return View("Index", model);
                }

                _recursoAppService.Atualizar(model.Recurso);

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

            return RedirectToAction("Index", new { idaplicacao = model.Recurso.AplicacaoId });
        }

        // GET: Recurso/Delete/5
        public ActionResult Delete(int idaplicacao, long? idrecurso)
        {
            try
            {
                var aplicacao = _aplicacaoAppService.ObterPorId(idaplicacao);
                if (aplicacao == null)
                    throw new NoRecordsFoundException("Aplicação não encontrado");

                var recurso = idrecurso != null ? _recursoAppService.Filtrar(f => f.AplicacaoId == aplicacao.Id && f.Id == idrecurso).SingleOrDefault() : null;
                if (idrecurso != null && recurso == null)
                    throw new NoRecordsFoundException("Recurso não encontrado");

                ViewBag.Delete = true;

                RecursosViewModel model = new RecursosViewModel
                {
                    Aplicacao = aplicacao,
                    RecursoSet = aplicacao.RecursoSet,
                    Recurso = recurso
                };

                return View("Index", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", new { idaplicacao = idaplicacao });
        }

        // POST: Recurso/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RecursosViewModel model)
        {
            try
            {
                var recurso = _recursoAppService.Filtrar(f => f.Id == id && f.AplicacaoId == model.Recurso.AplicacaoId).SingleOrDefault();
                if (recurso == null)
                    throw new NoRecordsFoundException("Recurso não encontrado");

                _recursoAppService.Remover(recurso);

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

            return RedirectToAction("Index", new { idaplicacao = model.Recurso.AplicacaoId });
        }

        public ActionResult Export(int id, long[] RecursoId = null)
        {
            try
            {
                if (RecursoId != null && RecursoId.Count() > 0)
                {
                    var recursos = _recursoAppService.Filtrar(f => RecursoId.Contains(f.Id));
                    ViewBag.Export = _recursoAppService.Export(recursos);
                }

                return Index(id);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", new { idaplicacao = id });
        }
    }
}
