using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LVSA.Base.Application.Exceptions;
using LVSA.Base.Presentation.ViewModels;
using LVSA.Security.Application.Interfaces;
using LVSA.Security.Application.Models;
using LVSA.Security.Application.ViewModels;
using LVSA.Security.Presentation.ViewModels;

namespace LVSA.Security.Presentation.Controllers
{
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IContextoAppService _contextoAppService;
        private readonly ITipoUsuarioAppService _tipoUsuarioAppService;

        /// <summary>
        /// Propriedade responsável de armazenar a ultima pesquisa do usuário
        /// </summary>
        private string _pesquisa
        {
            get
            {
                if (Session["_pesquisa"] == null)
                    return string.Empty;
                return (string)Session["_pesquisa"];
            }
            set
            {
                Session["_pesquisa"] = value;
            }
        }

        public UsuarioController(IUsuarioAppService usuarioAppService, IContextoAppService contextoAppService, ITipoUsuarioAppService tipoUsuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
            _contextoAppService = contextoAppService;
            _tipoUsuarioAppService = tipoUsuarioAppService;
        }


        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Contexto.IsAuthentication())
            {

                _usuarioAppService.SetSeguranca(Contexto.Seguranca);
                _contextoAppService.SetSeguranca(Contexto.Seguranca);
                _tipoUsuarioAppService.SetSeguranca(Contexto.Seguranca);
                if (requestContext.HttpContext.Request.Form["Pesquisa"] != null || !string.IsNullOrWhiteSpace(_pesquisa))
                {
                    if (!string.IsNullOrWhiteSpace(requestContext.HttpContext.Request.Form["Pesquisa"]))
                    {
                        _pesquisa = requestContext.HttpContext.Request.Form["Pesquisa"];

                        Contexto.SetLog(string.Format("O usuário {0} - {1} pesquisou Usuários pela palavra '{2}'", Contexto.Seguranca.CODUSUARIO, Contexto.Seguranca.Usuario.Nome, _pesquisa), 0);
                    }
                    else if (string.IsNullOrWhiteSpace(_pesquisa))
                        ModelState.AddModelError("Pesquisa", "Informe o campo para a busca");

                    List<UsuarioViewModel> usuarios = string.IsNullOrWhiteSpace(_pesquisa) ? new List<UsuarioViewModel> { } : _usuarioAppService.ObterPorNome(_pesquisa).ToList();
                    if (!string.IsNullOrWhiteSpace(_pesquisa) && usuarios.Count() == 0)
                    {
                        var usuario = _usuarioAppService.ObterPorCodigo(_pesquisa);
                        if (usuario != null)
                            usuarios.Add(usuario);
                    }

                    if (Contexto.Seguranca.Usuario.TipoUsuario == null || (Contexto.Seguranca.Usuario.TipoUsuario.Codigo != "ADM" && Contexto.Seguranca.Usuario.TipoUsuario.Codigo != "DES"))
                    {
                        bool exist = usuarios.Count() > 0;
                        usuarios = usuarios.Where(w => w.Id != Contexto.Seguranca.Usuario.Id).ToList();
                        if (exist && usuarios.Count() == 0)
                            ModelState.AddModelError("Pesquisa", "Você não tem permissão de gerênciar o próprio usuário");
                    }

                    ViewBag.UsuarioSet = usuarios;


                    ViewBag.Pesquisa = _pesquisa;
                }

                ViewBag.TipoUsuarioSet = _tipoUsuarioAppService.Filtrar(f => f.Ativo);
            }
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            AddShortcut("Ir para agrupamento", Url.Action("Usuario", "Agrupamento"), "fa fa-users");
            AddShortcut("Ir para grupos", Url.Action("Index", "Grupo"), "fa fa-users");
        }

        /// <summary>
        /// Exibe a interface de consulta de usuários
        /// </summary>
        /// <param name="id">Para valor diferente de 'L' a pesquisa atual será mantida</param>
        /// <returns>View</returns>
        public ActionResult Index(char id = 'L')
        {
            try
            {
                if (id == 'L')
                {
                    ModelState.Clear();

                    _pesquisa = string.Empty;
                    ViewBag.Pesquisa = string.Empty;
                    ViewBag.UsuarioSet = null;
                }

                return View(new UsuariosViewModel { });
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Exibe a interface de consulta de usuários
        /// </summary>
        /// <param name="Pesquisa">Valor do filtro escolhido pelo usuário</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult Index(string Pesquisa)
        {
            try
            {
                return View("Index", new UsuariosViewModel { });
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Action(long id, UsuariosViewModel model)
        {
            try
            {
                if (id > 0)
                    return Edit(id, model);
                return Create(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", new { id = 'P' });
        }

        public ActionResult Create()
        {
            try
            {
                UsuariosViewModel model = new UsuariosViewModel();

                model.Usuario = new UsuarioViewModel { };


                return View("Index", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", new { id = 'P' });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuariosViewModel model)
        {
            try
            {

                if (!ModelState.IsValid)
                    return View(model);

                _usuarioAppService.Incluir(model.Usuario);

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

            return RedirectToAction("Index", new { id = 'P' });
        }

        /// <summary>
        /// Exibe a modal com a interface de detalhes do usuário
        /// </summary>
        /// <param name="id">Id do usuário selecionado. Para valor = -1 ele não foi persistido ainda</param>
        /// <param name="codigo">CODUSUARIO do usuário selecionado</param>
        /// <returns>View</returns>
        public ActionResult Details(long id, string codigo)
        {
            try
            {
                UsuariosViewModel model = new UsuariosViewModel();
                model.Usuario = _usuarioAppService.ObterPorId(id, true);

                if (model == null)
                    throw new NoRecordsFoundException("Usuário não encontrado");

                ViewBag.Details = true;

                return View("Index", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", new { id = 'P' });
        }

        /// <summary>
        /// Exibe a modal com interface de edição do usuário
        /// </summary>
        /// <param name="id">Id do usuário selecionado. Para valor = -1 ele não foi persistido ainda</param>
        /// <param name="codigo">CODUSUARIO do usuário selecionado</param>
        /// <returns>View</returns>
        public ActionResult Edit(long id, string codigo)
        {
            try
            {
                UsuariosViewModel model = new UsuariosViewModel();

                model.Usuario = _usuarioAppService.ObterPorId(id);

                if (model == null)
                    throw new NoRecordsFoundException("Usuário não encontrado");

                return View("Index", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", new { id = 'P' });
        }

        /// <summary>
        /// Atualiza as informações do usuário
        /// </summary>
        /// <param name="id">Id do usuário selecionado.</param>
        /// <param name="codigo">CODUSUARIO do usuário selecionado</param>
        /// <param name="model">Informações do usuário</param>
        /// <returns>View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(long id, UsuariosViewModel model)
        {
            try
            {
                model.Usuario.Id = id;

                if (!ModelState.IsValid)
                    return View(model);

                _usuarioAppService.Atualizar(model.Usuario);

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

            return RedirectToAction("Index", new { id = 'P' });
        }
    }
}
