using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LVSA.Base.Application.Exceptions;
using LVSA.Base.Presentation.Exceptions;
using LVSA.Base.Presentation.ViewModels;
using LVSA.Security.Application.Interfaces;
using LVSA.Security.Application.Models;
using LVSA.Security.Application.ViewModels;
using LVSA.Security.Presentation.ViewModels;

namespace LVSA.Security.Presentation.Controllers
{
    public class AgrupamentoController : FiltroController
    {
        private readonly IGrupoAppService _grupoAppService;

        public AgrupamentoController(IGrupoAppService grupoAppService)
        {
            _grupoAppService = grupoAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _grupoAppService.SetSeguranca(Contexto.Seguranca, false);

            if (!string.IsNullOrWhiteSpace(requestContext.HttpContext.Request.Form["Pesquisa"]))
            {
                ViewBag.Pesquisa = requestContext.HttpContext.Request.Form["Pesquisa"];
                FCODUSUARIO = null;

                List<UsuarioViewModel> usuarios = string.IsNullOrWhiteSpace(requestContext.HttpContext.Request.Form["Pesquisa"]) ? new List<UsuarioViewModel> { } : _usuarioAppService.ObterPorNome(requestContext.HttpContext.Request.Form["Pesquisa"]).ToList();
                if (!string.IsNullOrWhiteSpace(requestContext.HttpContext.Request.Form["Pesquisa"]) && usuarios.Count() == 0)
                {
                    var usuario = _usuarioAppService.ObterPorCodigo(requestContext.HttpContext.Request.Form["Pesquisa"]);
                    if (usuario != null)
                        usuarios.Add(usuario);
                }

                if (Contexto.Seguranca.Usuario.TipoUsuario == null || (Contexto.Seguranca.Usuario.TipoUsuario.Codigo != "ADM" && Contexto.Seguranca.Usuario.TipoUsuario.Codigo != "DES"))
                {
                    bool exist = usuarios.Count() > 0;
                    usuarios = usuarios.Where(w => w.Id != Contexto.Seguranca.Usuario.Id).ToList();
                    if (exist && usuarios.Count() == 0)
                        ModelState.AddModelError("CODUSUARIO", "Você não tem permissão de gerênciar o próprio usuário");
                }

                if (usuarios.Count() > 0)
                {
                    if (usuarios.Count() == 1 && ControllerContext.RouteData.Values["action"].ToString() == "Usuario")
                        FCODUSUARIO = usuarios.Single().Id;
                    else
                        ViewBag.UsuarioSet = usuarios;
                }
                else
                    ModelState.AddModelError("Pesquisa", "Não existe usuários para essa busca");
            }

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
                    ModelState.AddModelError("AplicacaoId", "Não existe aplicação concedida para o nível de ensino.");
            }

            if (FFilialId != null && FAplicacaoId != null && ViewBag.AplicacaoSet != null)
            {
                if (ControllerContext.RouteData.Values["action"].ToString() == "Grupo")
                {
                    FGrupoId = requestContext.HttpContext.Request.Form["GrupoId"] != null ? (!string.IsNullOrWhiteSpace(requestContext.HttpContext.Request.Form["GrupoId"]) ? Convert.ToInt16(requestContext.HttpContext.Request.Form["GrupoId"]) : (long?)null) : FGrupoId;

                    var aplicacao = _aplicacaoAppService.ObterPorId((int)FAplicacaoId);
                    var grupos = aplicacao.GrupoSet.Where(w => w.FilialId == FFilialId && w.AplicacaoId == FAplicacaoId && w.Ativo);
                    if (grupos.Count() > 0)
                    {
                        if (grupos.Count() == 1)
                            FGrupoId = grupos.Single().Id;
                        else if (FGrupoId == null && requestContext.HttpContext.Request.Form["GrupoId"] != null)
                            ModelState.AddModelError("GrupoId", "Informe o grupo para o filtro");
                    }
                    else
                    {
                        FGrupoId = null;
                        ModelState.AddModelError("GrupoId", "Não existe grupo para aplicação e o nível de ensino");
                    }

                    ViewBag.GrupoSet = grupos;
                }

                if (ControllerContext.RouteData.Values["action"].ToString() == "Usuario")
                {
                    if (FCODUSUARIO != null)
                    {
                        var aplicacao = _aplicacaoAppService.ObterPorId((int)FAplicacaoId);
                        ViewBag.GrupoSet = aplicacao.GrupoSet.Where(w => w.FilialId == FFilialId && w.Ativo);
                    }
                    else
                        ViewBag.GrupoSet = null;
                }
            }



            ViewBag.FilialId = FFilialId;
            ViewBag.AplicacaoId = FAplicacaoId;
            ViewBag.CODUSUARIO = FCODUSUARIO;
            ViewBag.GrupoId = FGrupoId;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            AddShortcut("Ir para grupos", Url.Action("Index", "Grupo"), "fa fa-users");
            AddShortcut("Ir para usuários", Url.Action("Index", "Usuario"), "fa fa-user");
            AddShortcut("Ir para permissões", Url.Action("Grupo", "Permissao"), "fa fa-shield");
        }

        public ActionResult Usuario(string id = null)
        {
            try
            {
                ModelState.Clear();

                AgrupamentosViewModel model = new AgrupamentosViewModel { };

                FFilialId = null;
                FAplicacaoId = null;

                if (string.IsNullOrWhiteSpace(id))
                    FCODUSUARIO = null;
                else
                {
                    model.Usuario = _usuarioAppService.ObterPorCodigo(id);
                    if (model.Usuario != null)
                        FCODUSUARIO = model.Usuario.Id;
                }


                ViewBag.FilialId = FFilialId;
                ViewBag.AplicacaoId = FAplicacaoId;
                ViewBag.CODUSUARIO = FCODUSUARIO;
                ViewBag.GrupoSet = null;

                return View("Usuario", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Usuario(AgrupamentosViewModel model)
        {
            try
            {
                if (FFilialId == null)
                    ModelState.AddModelError("FilialId", "Informe a filial para o filtro");



                if (ViewBag.AplicacaoSet != null && ((IEnumerable<AplicacaoViewModel>)ViewBag.AplicacaoSet).Count() > 0)
                {
                    if (FAplicacaoId == null)
                        ModelState.AddModelError("AplicacaoId", "Informe a aplicação para o filtro");
                }
                else if (FFilialId != null)
                    ModelState.AddModelError("AplicacaoId", "Não existe aplicação concedida para o nível de ensino.");

                if (FCODUSUARIO == null)
                {
                    ModelState.AddModelError("CODUSUARIO", "Informe o usuário para o agrupamento");
                    model.Usuario = null;
                }
                else
                {
                    model.Usuario = _usuarioAppService.Filtrar(f => f.Id == FCODUSUARIO).SingleOrDefault();

                    if (model.Usuario.Id == -1)
                    {
                        var _gruposet = model.GrupoSet;

                        model.Usuario = _usuarioAppService.Incluir(new UsuarioViewModel { Id = (long)FCODUSUARIO });
                        model.Usuario = _usuarioAppService.ObterPorId(model.Usuario.Id);

                        model.GrupoSet = _gruposet;
                    }

                    if (model.GrupoSet != null)
                    {
                        model.Usuario.GrupoSet = model.GrupoSet;
                        _usuarioAppService.Agrupar(model.Usuario);

                        Gritters.Add(new GritterViewModel
                        {
                            Tittle = "Sucesso!",
                            Message = "Operação realizada com sucesso.",
                            Style = GritterStyle.Success,
                        });

                        model.Usuario.GrupoSet = model.GrupoSet.Where(w => w.Selecionado);
                    }
                }


                return View("Usuario", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Usuarios(long id, long codigo)
        {
            try
            {
                AgrupamentosViewModel model = new AgrupamentosViewModel();

                model.Usuario = _usuarioAppService.ObterPorId(id);

                if (model.Usuario == null)
                    throw new NoRecordsFoundException("Usuário não encontrado");

                return View("Usuario", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return View("Usuario");
        }

        public ActionResult Grupo(long? id = null)
        {
            try
            {
                ModelState.Clear();

                AgrupamentosViewModel model = new AgrupamentosViewModel { };

                if (id == null)
                {
                    FAplicacaoId = null;
                    FGrupoId = null;
                    FFilialId = null;
                    FAplicacaoId = null;

                    ViewBag.AplicacaoSet = null;
                }
                else
                {
                    model.Grupo = _grupoAppService.ObterPorId((long)id);
                    if (model.Grupo != null)
                    {
                        FAplicacaoId = model.Grupo.AplicacaoId;
                        FGrupoId = model.Grupo.Id;
                    }
                    else
                    {
                        FAplicacaoId = null;
                        FGrupoId = null;
                    }
                }


                ViewBag.FilialId = FFilialId;
                ViewBag.AplicacaoId = FAplicacaoId;
                ViewBag.GrupoId = FGrupoId;
                ViewBag.UsuarioSet = null;

                return View("Grupo", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Grupo(AgrupamentosViewModel model, string Remover = null)
        {
            try
            {
                if (Remover != null)
                {
                    if (Remover == string.Empty)
                    {
                        _grupoAppService.Esvaziar(model.Grupo);

                        Gritters.Add(new GritterViewModel
                        {
                            Tittle = "Sucesso!",
                            Message = "Operação realizada com sucesso.",
                            Style = GritterStyle.Success,
                        });
                    }
                    else
                    {
                        long usuarioid = 0;
                        if (long.TryParse(Remover, out usuarioid))
                        {
                            model.Usuario = _usuarioAppService.ObterPorId(usuarioid);
                            if (model.Usuario.GrupoSet.Where(w => w.Id == FGrupoId).Count() == 0)
                                throw new NoRecordsFoundException("Grupo não encontrado para o usuário");

                            _grupoAppService.Retirar(model.Grupo, model.Usuario);

                            Gritters.Add(new GritterViewModel
                            {
                                Tittle = "Sucesso!",
                                Message = "Operação realizada com sucesso.",
                                Style = GritterStyle.Success,
                            });
                        }
                    }
                }
                else if (model.Grupo != null && model.Grupo.UsuarioSet != null)
                {
                    
                    _grupoAppService.Agrupar(model.Grupo);

                    Gritters.Add(new GritterViewModel
                    {
                        Tittle = "Sucesso!",
                        Message = "Operação realizada com sucesso.",
                        Style = GritterStyle.Success,
                    });
                }

                if (FGrupoId != null)
                    model.Grupo = _grupoAppService.ObterPorId((long)FGrupoId);

                return View("Grupo", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}