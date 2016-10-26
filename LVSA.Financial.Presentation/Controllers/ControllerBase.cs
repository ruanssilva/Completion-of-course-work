﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Financial.Presentation.Controllers
{
    public abstract class ControllerBase : LVSA.Base.Presentation.Controllers.AutenticaController
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