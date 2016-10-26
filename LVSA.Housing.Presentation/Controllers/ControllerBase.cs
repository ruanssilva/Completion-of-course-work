
using LVSA.Base.Presentation.App_Start;
using LVSA.Global.Application.Interfaces;
using LVSA.Global.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using LVSA.Housing.Application.ViewModels;
using LVSA.Housing.Application.Interfaces;
using LVSA.Housing.Presentation.Models;

namespace LVSA.Housing.Presentation.Controllers
{
    public class ControllerBase : LVSA.Base.Presentation.Controllers.AutenticaController
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
                        TempData["Navbar"] += PartialViewToString("_PartialView/Noticias", Contexto.Noticias);
                }
            }
        }


    }
}
