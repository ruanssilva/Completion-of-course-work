
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using System.Net.Http;
using LVSA.Security.Service.Controllers;
using LVSA.Security.Infrastructure.CrossCutting.Identity;
using LVSA.Security.Application.ViewModels;
using LVSA.Security.Application.Models;
using System.Net;
using LVSA.Base.Infrastructure.Data.DbContexts;
using System.Web.Configuration;

namespace LVSA.Security.Service.Filters
{
    public class AutenticaFilterAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.ControllerContext.Controller is AutenticaController)
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                    throw new HttpResponseException(actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "É necessário autenticar antes de usar este recurso"));

                AutenticaController controller = (AutenticaController)actionContext.ControllerContext.Controller;
                if (controller.Seguranca == null)
                {
                    AppIdentityUser user = controller.UserManager.FindById(HttpContext.Current.User.Identity.GetUserId());
                    if (user == null)
                        throw new Exception("Registro não encontrado");

                    UsuarioViewModel usuario = controller._usuarioAppService.ObterPorId((long)user.UsuarioId, true);
                    if (usuario == null)
                        throw new Exception("Registro não encontrado");


                    controller.Seguranca = new Seguranca
                    {
                        Id = HttpContext.Current.User.Identity.GetUserId(),
                        Usuario = usuario
                    };
                }

            }

            base.OnActionExecuting(actionContext);
        }
    }
}