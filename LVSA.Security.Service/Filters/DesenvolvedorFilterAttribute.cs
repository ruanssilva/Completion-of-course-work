using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using LVSA.Security.Service.Controllers;

namespace LVSA.Security.Service.Filters
{
    public class DesenvolvedorFilterAttribute : AutenticaFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);

            if (actionContext.ControllerContext.Controller is DesenvolvedorController)
            {
                DesenvolvedorController controller = (DesenvolvedorController)actionContext.ControllerContext.Controller;
                if (controller.Seguranca.Usuario.TipoUsuario == null || (controller.Seguranca.Usuario.TipoUsuario.Codigo != "DES" && controller.Seguranca.Usuario.TipoUsuario.Codigo != "ADM"))
                    throw new HttpResponseException(actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "É necessário ser um desenvolvedor ou administrador para acessar este recurso"));
            }
        }
    }
}