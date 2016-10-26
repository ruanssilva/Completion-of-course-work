using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using LVSA.Security.Service.Models;
using LVSA.Security.Infrastructure.CrossCutting.Identity;
using LVSA.Security.Application.Interfaces;
using LVSA.Security.Service.App_Start;
using Ninject;
using Ninject.Web.Common;
using LVSA.Security.Application.ViewModels;

namespace LVSA.Security.Service.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public ApplicationOAuthProvider()
        {
            _usuarioAppService = NinjectWebCommon.RegisterServices().Get<IUsuarioAppService>();
        }

        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
            : this()
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 2,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            userManager.UserValidator = new UserValidator<AppIdentityUser>(userManager)
            {
                RequireUniqueEmail = false,
                AllowOnlyAlphanumericUserNames = false
            };

            try
            {
                
            }
            catch (Exception ex)
            {
                context.SetError("WSTBC", ex.Message);
                return;
            }

            UsuarioViewModel usuario = _usuarioAppService.Filtrar(f => !f.Bloqueado && (f.Codigo == context.UserName || f.Email == context.UserName)).SingleOrDefault();
            if (usuario == null)
            {
                context.SetError("Usuario", "Usuário sem permissão de acesso ou bloqueado");
                return;
            }

            AppIdentityUser user = userManager.FindByName(usuario.Codigo);
            if (user == null)
            {
                user = new AppIdentityUser { UserName = context.UserName, Email = usuario.Email, UsuarioId = usuario.Id };

                IdentityResult result = userManager.Create(user, "abc123");

                if (!result.Succeeded)
                {
                    context.SetError("Identity", "Não foi possível gerar o token para a sessão");
                    return;
                }

                user = userManager.FindByName(context.UserName);

                if (user == null)
                {
                    context.SetError("Identity", "Não foi possível gerar o token para a sessão");
                    return;
                }
            }

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
               OAuthDefaults.AuthenticationType);
            ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
                CookieAuthenticationDefaults.AuthenticationType);

            AuthenticationProperties properties = CreateProperties(user.UserName);
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(cookiesIdentity);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
}