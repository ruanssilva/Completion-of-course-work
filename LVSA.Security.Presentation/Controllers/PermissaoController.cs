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
    public class PermissaoController : FiltroController
    {
        private readonly IGrupoAppService _grupoAppService;
        private readonly IRecursoAppService _recursoAppService;
        public PermissaoController(IGrupoAppService grupoAppService, IRecursoAppService recursoAppService)
        {
            _grupoAppService = grupoAppService;
            _recursoAppService = recursoAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _grupoAppService.SetSeguranca(Contexto.Seguranca, false);
            _recursoAppService.SetSeguranca(Contexto.Seguranca, false);

            if (FFilialId != null)
            {
                ViewBag.AplicacaoSet = null;
                var aplicacoes = _contextoAppService.Acessos(f => f.FilialId == FFilialId && f.Ativo).GroupBy(g => g.Id).Select(s => s.First());
                if (aplicacoes.Count() > 0)
                {
                    if (aplicacoes.Count() == 1)
                        FAplicacaoId = aplicacoes.Single().Id;
                    else if (FAplicacaoId == null)
                        ModelState.AddModelError("AplicacaoId", "Informe a aplicação para o filtro");

                    ViewBag.AplicacaoSet = aplicacoes;
                }
                else
                    ModelState.AddModelError("AplicacaoId", "Não existe aplicação concedida para o nível de ensino.");
            }

            if (FFilialId != null && FAplicacaoId != null && ViewBag.AplicacaoSet != null)
            {
                FGrupoId = requestContext.HttpContext.Request.Form["GrupoId"] != null ? (!string.IsNullOrWhiteSpace(requestContext.HttpContext.Request.Form["GrupoId"]) ? Convert.ToInt16(requestContext.HttpContext.Request.Form["GrupoId"]) : (long?)null) : FGrupoId;

                var aplicacao = _aplicacaoAppService.ObterPorId((int)FAplicacaoId);
                var grupos = aplicacao.GrupoSet.Where(w => w.FilialId == FFilialId  && w.AplicacaoId == FAplicacaoId && w.Ativo);
                if (grupos.Count() > 0)
                {
                    if (grupos.Count() == 1)
                        FGrupoId = grupos.Single().Id;
                    else if (FGrupoId == null)
                        ModelState.AddModelError("GrupoId", "Informe o grupo para o filtro");
                }
                else
                {
                    FGrupoId = null;
                    ModelState.AddModelError("GrupoId", "Não existe grupo para aplicação e o nível de ensino");
                }

                ViewBag.GrupoSet = grupos;
            }

            ViewBag.FilialId = FFilialId;
            ViewBag.AplicacaoId = FAplicacaoId;
            ViewBag.GrupoId = FGrupoId;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            AddShortcut("Ir para grupos", Url.Action("Index", "Grupo"), "fa fa-users");
        }


        public ActionResult Grupo(long? id = null)
        {
            try
            {
                ModelState.Clear();

                PermissoesViewModel model = new PermissoesViewModel { };
                if (id != null)
                {
                    model.Grupo = _grupoAppService.ObterPorId((long)id);

                    if (model.Grupo == null)
                        throw new NoRecordsFoundException("Grupo não encontrado");

                    FFilialId = model.Grupo.FilialId;
                    FAplicacaoId = model.Grupo.AplicacaoId;
                    FGrupoId = model.Grupo.Id;

                    model.Aplicacao = _aplicacaoAppService.ObterPorId((int)FAplicacaoId);

                    ViewBag.AplicacaoSet = _contextoAppService.Acessos(f => f.FilialId == FFilialId && f.Ativo).GroupBy(g => g.Id).Select(s => s.First());
                    ViewBag.GrupoSet = model.Aplicacao.GrupoSet.Where(w => w.FilialId == FFilialId && w.AplicacaoId == FAplicacaoId && w.Ativo);
                }
                else
                {
                    FFilialId = null;
                    FAplicacaoId = null;
                    FGrupoId = null;
                    ViewBag.AplicacaoSet = null;

                }

                ViewBag.FilialId = FFilialId;
                ViewBag.AplicacaoId = FAplicacaoId;
                ViewBag.GrupoId = FGrupoId;


                return View("Grupo", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Grupo(PermissoesViewModel model)
        {
            try
            {
                if (model.Grupo != null && model.Grupo.PermissaoSet != null)
                {
                    _grupoAppService.Permitir(model.Grupo);

                    Gritters.Add(new GritterViewModel
                    {
                        Tittle = "Sucesso!",
                        Message = "Operação realizada com sucesso.",
                        Style = GritterStyle.Success,
                    });

                    Contexto.SetLog(string.Format("O usuário {0} - {1} alterou as permissões do grupo {2}", Contexto.Seguranca.CODUSUARIO, Contexto.Seguranca.Usuario.Nome, model.Grupo.Id), 0);
                }

                if (FGrupoId != null)
                    model.Grupo = _grupoAppService.ObterPorId((long)FGrupoId);

                if (FAplicacaoId != null)
                {
                    model.Aplicacao = _aplicacaoAppService.ObterPorId((int)FAplicacaoId);
                    model.Aplicacao.RecursoSet = model.Aplicacao.RecursoSet.Where(w => w.RecursoPaiId == null && !w.Herdado && w.Ativo).Distinct();
                }

                return Grupo(FGrupoId);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
