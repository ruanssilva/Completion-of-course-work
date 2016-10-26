using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LVSA.Base.Presentation.App_Start;
using LVSA.Security.Application.Interfaces;
using Ninject;
using Ninject.Web.Common;
using LVSA.Security.Application.Models;
using LVSA.Base.Presentation.Rest;
using System.Web.Configuration;
using LVSA.Base.Presentation.Models;
using LVSA.Base.Presentation.ViewModels;
using System.Web.Http;
using LVSA.Base.Presentation.Hub;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Client;

namespace LVSA.Base.Presentation.Controllers
{
    public class AutenticaController : ControllerBase
    {
        private int _caching
        {
            get
            {
                int result = 5;
                if (!string.IsNullOrWhiteSpace(WebConfigurationManager.AppSettings["Caching"]))
                    int.TryParse(WebConfigurationManager.AppSettings["Caching"], out result);

                return result;
            }
        }



        protected string ConnectionString
        {
            get
            {
                return LVSA.Base.Infrastructure.Data.DbContexts.BaseContext.Connection;
            }
        }

        private IEnumerable<Contexto> _contextos
        {
            get
            {
                return GetCache<IEnumerable<Contexto>>("_contexto");
            }
            set
            {
                SetCache<IEnumerable<Contexto>>(value, "_contexto");
            }
        }
        protected IEnumerable<Contexto> Contextos
        {
            get
            {
                return _contextos ?? new List<Contexto> { };
            }
            set
            {
                _contextos = value;
            }
        }
        private Contexto _contexto
        {
            get
            {

                if (!string.IsNullOrWhiteSpace(Token))
                    return Contextos.Where(w => w.Provider == Token && w.UltimaAtividade > DateTime.Now.AddMinutes(-this._caching - 1)).FirstOrDefault();
                return null;
            }
            set
            {
                if (value != null)
                    Contextos = Contextos.Where(w => w.Provider != value.Provider && w.UltimaAtividade > DateTime.Now.AddMinutes(-this._caching - 1));

                if (value != null && !string.IsNullOrWhiteSpace(value.Provider))
                {
                    value.UltimaAtividade = DateTime.Now;

                    Contextos = Contextos.Concat(new List<Contexto> { value });
                }
            }
        }
        public Contexto Contexto
        {
            get
            {
                if (_contexto == null && Token != null)
                    _contexto = new Contexto(Token);
                return _contexto ?? new Contexto(Token) { };
            }
            set
            {
                _contexto = value;
            }
        }

        protected virtual string Parametro(string key)
        {
            if (Contexto != null && Contexto.Seguranca != null && Contexto.Seguranca.Parametros != null)
                return Contexto.Seguranca.Parametros.Where(w => w.Key == key).Select(s => s.Value).FirstOrDefault();
            return string.Empty;
        }

        private HubConnection _lConnection { get; set; }
        protected HubConnection LConnection
        {
            get
            {
                if (_lConnection == null)
                    _lConnection = new HubConnection(HttpContext.Request.Url.Scheme + "://" + HttpContext.Request.Url.Host + ":" + HttpContext.Request.Url.Port + "/" + VirtualPathUtility.ToAbsolute("~/signalr"), new Dictionary<string, string> { { "token", Token } });
                return _lConnection;
            }
        }
        private IHubProxy _lGritterHub { get; set; }
        protected IHubProxy LGritterHub
        {
            get
            {
                if (_lGritterHub == null)
                    _lGritterHub = LConnection.CreateHubProxy("GritterHub");

                if (LConnection.State != ConnectionState.Connected)
                    LConnection.Start().Wait();
                return _lGritterHub;
            }
        }

        private IHubProxy _gstalkerHub { get; set; }
        protected IHubProxy GStalkerHub
        {
            get
            {
                if (_gstalkerHub == null)
                    _gstalkerHub = GConnection.CreateHubProxy("StalkerHub");

                if (GConnection.State != ConnectionState.Connected)
                    GConnection.Start().Wait();

                return _gstalkerHub;
            }
            
        }

        private HubConnection _gConnection { get; set; }
        protected HubConnection GConnection
        {
            get
            {
                if (_gConnection == null)
                {
                    _gConnection = new HubConnection(System.Web.Configuration.WebConfigurationManager.AppSettings["Address_SignalR"], new Dictionary<string, string> { { "token", Token } });

                    if (_gGritterHub == null)
                        _gGritterHub = GConnection.CreateHubProxy("GritterHub");

                    if (_gstalkerHub == null)
                        _gstalkerHub = GConnection.CreateHubProxy("StalkerHub");

                }

                return _gConnection;
            }
            set
            {
                _gConnection = value;
            }
        }
        private IHubProxy _gGritterHub { get; set; }
        protected IHubProxy GGritterHub
        {
            get
            {
                

                if (_gGritterHub == null)
                    _gGritterHub = GConnection.CreateHubProxy("GritterHub");

                if (GConnection.State != ConnectionState.Connected)
                    GConnection.Start().Wait();

                return _gGritterHub;
            }
        }
        protected AplicacaoRest _aplicacaoRest { get; set; }
        private HttpCookie _cookie { get; set; }
        public string Token
        {
            get
            {
                return _cookie["LVSA.Base.Presentation.Controllers#Token"];
            }
            set
            {
                if (_cookie.Values.AllKeys.Contains("LVSA.Base.Presentation.Controllers#Token"))
                    _cookie.Values.Set("LVSA.Base.Presentation.Controllers#Token", value);
                else
                    _cookie.Values.Add("LVSA.Base.Presentation.Controllers#Token", value);
            }
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _cookie = Request.Cookies["LVSA.Base.Presentation"] ?? new HttpCookie("LVSA.Base.Presentation");
            _cookie.Expires = DateTime.Now.AddMinutes(30);

            _aplicacaoRest = new AplicacaoRest(Token);

            Response.Cookies.Add(_cookie);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Contexto.IsAuthentication())
            {


                //GStalkerHub.Invoke("WhereIam", filterContext.ActionDescriptor.ActionName, filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, Request.Url.AbsoluteUri, ((int)(DateTime.Now - Contexto.AtualizadoEm).TotalMinutes)).ContinueWith(task =>
                //{
                //    if (task.IsFaulted)
                //    {
                //        Console.WriteLine("ChangePort faulted: {0}", task.Exception.Flatten());
                //    }

                //    GConnection.Stop();
                //    //GConnection.Dispose();
                //    //GConnection = null;
                //});

                if (Contexto.AtualizadoEm < DateTime.Now.AddMinutes(-_caching))
                    Contexto.Reload();

                //force get temporary
                string gambiarra = ConnectionString;

                //LGritterHub.Invoke("Information", "", "Atenção!", "Esta é uma mensagem apenas local na apliacação.");
                //GGritterHub.Invoke("Information", "", "Atenção!", "Esta é uma mensagem global nas apliacações.").ContinueWith(task =>
                //{
                //    if (task.IsFaulted)
                //    {
                //        Console.WriteLine("ChangePort faulted: {0}", task.Exception.Flatten());
                //    }

                //    GConnection.Stop();
                //    //GConnection.Dispose();
                //    //GConnection = null;
                //});

                //GGritterHub.Invoke("Information", "", "Atenção! 2", "Esta é uma mensagem global nas apliacações. 2").ContinueWith(task =>
                //{
                //    if (task.IsFaulted)
                //    {
                //        Console.WriteLine("ChangePort faulted: {0}", task.Exception.Flatten());
                //    }

                //    GConnection.Stop();
                //    //GConnection.Dispose();
                //    //GConnection = null;
                //});

                TempData["LVSA.Base.Infrastructure.Data.DbContexts.Ambiente"] = LVSA.Base.Infrastructure.Data.DbContexts.BaseContext.Ambiente;

                if (!(filterContext.Controller is LoginController && filterContext.ActionDescriptor.ActionName == "Logout"))
                {
                    if (Contexto.Seguranca.Coligada == null || Contexto.Seguranca.Filial == null)
                    {
                        if (!(filterContext.Controller is ContextoController && filterContext.ActionDescriptor.ActionName == "Index"))
                            filterContext.Result = RedirectToAction("Index", "Contexto");
                    }
                    else
                    {
                        try
                        {
                            if (Contexto.Seguranca.Aplicacao == null || Contexto.Seguranca.Aplicacao.Nome != WebConfigurationManager.AppSettings["Name_Application"])
                            {
                                if (!string.IsNullOrWhiteSpace(WebConfigurationManager.AppSettings["Name_Application"]))
                                {
                                    if (Contexto.Seguranca.AplicacaoSet == null || Contexto.Seguranca.AplicacaoSet.Count() == 0)
                                        Contexto.Reload();

                                    string name = WebConfigurationManager.AppSettings["Name_Application"];

                                    if (Contexto.Seguranca.AplicacaoSet.Select(s => s.Nome).Contains(WebConfigurationManager.AppSettings["Name_Application"]))
                                        Contexto.SetAplicacao(Contexto.Seguranca.AplicacaoSet.Where(w => w.Nome == WebConfigurationManager.AppSettings["Name_Application"]).First());
                                    else
                                        throw new Exception("Sem acesso a aplicação");

                                    Contexto.Reload();
                                }
                                else
                                    throw new Exception("Aplicação não definida");
                            }

                            if (Contexto.Seguranca != null && Contexto.Seguranca.Aplicacao != null && Contexto.Seguranca.Aplicacao.ParametroSet != null)
                            {
                                string[] keys = Contexto.Seguranca.Aplicacao.ParametroSet.Where(w => w.Obrigatorio).Select(s => s.Codigo).ToArray();
                                foreach (var key in Contexto.Seguranca.Aplicacao.ParametroSet.Select(s => s.Codigo))
                                    if (!Contexto.Seguranca.Parametros.ContainsKey(key) || (Contexto.Seguranca.Parametros.Where(w => keys.Contains(w.Key) && string.IsNullOrWhiteSpace(w.Value)).Count() != 0))
                                        if (!(filterContext.Controller is ParamController && filterContext.ActionDescriptor.ActionName == "Index") && !(filterContext.Controller is ContextoController && filterContext.ActionDescriptor.ActionName == "Index"))
                                        {
                                            filterContext.Result = RedirectToAction("Index", "Param");
                                            break;
                                        }
                            }

                            if (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName != "Home" && !(filterContext.Controller is ContextoController) && !(filterContext.Controller is LoginController) && !(filterContext.Controller is ParamController) && !(filterContext.Controller is ErroController) && !(filterContext.Controller is PesquisaController) && !(filterContext.Controller is AppController) && Contexto.Seguranca.RecursoSet.Where(w => w.Controller == filterContext.ActionDescriptor.ControllerDescriptor.ControllerName && w.Action == filterContext.ActionDescriptor.ActionName && w.Ativo).Count() == 0)
                            {
                                Contexto.SetLog(string.Format("O usuário {0} - {1} teve acesso bloqueado para a controller '{2}' e action '{3}'", Contexto.Seguranca.CODUSUARIO, Contexto.Seguranca.Usuario.Nome, filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, filterContext.ActionDescriptor.ActionName), 2);

                                //filterContext.Result = RedirectToAction("Index", "Erro", new { id = "403" });
                                Gritters.Add(new GritterViewModel
                                {
                                    Tittle = "Atenção! Você não tem acesso a este recurso",
                                    Message = "Essa funcionalidade que tenta acessar, é de uso restrito a alguns usuários.",
                                    Center = false,
                                    Style = GritterStyle.Warning
                                });
                            }
                            else
                                TempData["Recurso"] = Contexto.Seguranca.RecursoSet.Where(w => w.Controller == filterContext.ActionDescriptor.ControllerDescriptor.ControllerName && w.Action == filterContext.ActionDescriptor.ActionName && w.Ativo).FirstOrDefault();


                        }
                        catch
                        {
                            if (!((filterContext.Controller is AppController || filterContext.Controller is ContextoController) && filterContext.ActionDescriptor.ActionName == "Index"))
                                filterContext.Result = RedirectToAction("Index", "App");
                        }
                    }
                }

                TempData["Seguranca"] = Contexto.Seguranca;
                TempData["Provider"] = Contexto.Provider;
            }
            else
                if (!(filterContext.Controller is LoginController && filterContext.ActionDescriptor.ActionName == "Index"))
                    filterContext.Result = RedirectToAction("Index", "Login");

            base.OnActionExecuting(filterContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
                return;

            try
            {
                if (Contexto.IsAuthentication())
                    Contexto.SetLog(filterContext.Exception.InnerException != null ? filterContext.Exception.InnerException.Message : filterContext.Exception.Message, 1);
            }
            catch { }

            HttpResponseException httpexception = null;

            try
            {
                httpexception = (HttpResponseException)filterContext.Exception;
            }
            catch { }

            if (httpexception != null && httpexception.Response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                Token = null;
                filterContext.Result = RedirectToAction("Index", "Login");
            }
            else
                base.OnException(filterContext);


            filterContext.ExceptionHandled = true;

        }
    }
}