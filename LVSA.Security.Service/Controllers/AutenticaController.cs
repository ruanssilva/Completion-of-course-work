using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web;
using LVSA.Security.Infrastructure.CrossCutting.Identity;
using LVSA.Security.Infrastructure.CrossCutting.Identity.DbContext;
using System.Security.Claims;
using System.Net.Http;
using System.Collections.Generic;
using LVSA.Security.Application.Models;
using System.Linq;
using System;
using LVSA.Security.Application.Interfaces;
using LVSA.Security.Service.Filters;
using LVSA.Security.Service.App_Start;
using Ninject;
using Ninject.Web.Common;
using LVSA.Noticia.Application.ViewModels;
using LVSA.Noticia.Application.Interfaces;
using LVSA.Security.Service.Models;
using LVSA.Security.Application.ViewModels;
using System.Web.Configuration;

namespace LVSA.Security.Service.Controllers
{
    [AutenticaFilterAttribute]
    public abstract class AutenticaController : ApiControllerBase
    {
        public readonly IUsuarioAppService _usuarioAppService;
        public readonly IContextoAppService _contextoAppService;
        public readonly IAplicacaoAppService _aplicacaoAppService;


        public AutenticaController()
            : this(new UserManager<AppIdentityUser>(new UserStore<AppIdentityUser>(new IdentityContext())))
        {
            _usuarioAppService = NinjectWebCommon.RegisterServices().Get<IUsuarioAppService>();
            _contextoAppService = NinjectWebCommon.RegisterServices().Get<IContextoAppService>();
            _aplicacaoAppService = NinjectWebCommon.RegisterServices().Get<IAplicacaoAppService>();
        }

        public UserManager<AppIdentityUser> UserManager { get; private set; }

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

        private List<Log> _logs
        {
            get
            {
                return GetCache<List<Log>>("_logs");
            }
            set
            {
                SetCache<List<Log>>(value, "_logs");
            }
        }

        public List<Log> Logs
        {
            get { return _logs ?? new List<Log> { }; }
            set
            {
                _logs = value;
            }
        }

        private IEnumerable<Seguranca> _segurancas
        {
            get
            {
                return GetCache<IEnumerable<Seguranca>>("_security");
            }
            set
            {
                SetCache<IEnumerable<Seguranca>>(value, "_security");
            }
        }
        protected IEnumerable<Seguranca> Segurancas
        {
            get
            {
                return _segurancas ?? new List<Seguranca> { };
            }
            set
            {
                _segurancas = value;
            }
        }

        private Seguranca _seguranca
        {
            get
            {
                if (!Seguranca.ColigadaSetIsLoad && !Seguranca.FilialSetIsLoad)
                    Seguranca.SetIContexto(_contextoAppService);

                if (!Seguranca.AplicacaoSetIsLoad)
                    Seguranca.SetIAplicacao(_aplicacaoAppService);

                if (HttpContext.Current.User.Identity.IsAuthenticated)
                    return Segurancas.Where(w => w.Id == User.Identity.GetUserId()).FirstOrDefault();
                return null;
            }
            set
            {
                if (value != null)
                    Segurancas = Segurancas.Where(w => w.Id != value.Id && w.UltimaAtividade > DateTime.Now.AddMinutes(-_caching) && (w.Usuario != null && !w.Usuario.Desconectado));

                if (User.Identity.IsAuthenticated && value != null)
                {
                    value.Id = User.Identity.GetUserId();
                    value.UltimaAtividade = DateTime.Now;

                    Segurancas = Segurancas.Concat(new List<Seguranca> { value });
                }
            }
        }

        public Seguranca Seguranca
        {
            get
            {
                if (_seguranca == null || _seguranca.Usuario.Desconectado)
                    return null;

                _seguranca.UltimaAtividade = DateTime.Now;

                return _seguranca;
            }
            set
            {
                _seguranca = value;
            }
        }


        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        public AutenticaController(UserManager<AppIdentityUser> userManager)
        {
            UserManager = userManager;
        }

        protected virtual void SignIn(AppIdentityUser user, bool isPersistent)
        {
            SignOut();

            ClaimsIdentity identity = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        protected virtual void SignOut()
        {
            Seguranca.Usuario.Desconectado = true;
            AuthenticationManager.SignOut();
        }
    }
}