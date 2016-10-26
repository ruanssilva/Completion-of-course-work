using LVSA.Base.Presentation.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Social.Presentation.Controllers
{
    public abstract class ControllerBase : AutenticaController
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (TempData["Navbar"] == null)
            {
                TempData["Navbar"] = string.Empty;

                if (Contexto.IsAuthentication())
                {
                    if (Contexto.Seguranca.ColigadaId != null && Contexto.Seguranca.FilialId != null && Contexto.Seguranca.AplicacaoId != null)
                        TempData["Navbar"] += PartialViewToString("_PartialView/Mensagens", null);

                    if (Contexto.Seguranca.ColigadaId != null && Contexto.Seguranca.FilialId != null && Contexto.Seguranca.AplicacaoId != null)
                        TempData["Navbar"] += PartialViewToString("_PartialView/Notificacoes", null);
                }
            }
        }
    }
}