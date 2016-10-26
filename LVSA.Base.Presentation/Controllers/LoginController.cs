using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LVSA.Base.Presentation.Exceptions;
using LVSA.Base.Presentation.Models;
using LVSA.Base.Presentation.Rest;
using LVSA.Base.Presentation.ViewModels;
using LVSA.Security.Application.ViewModels;

namespace LVSA.Base.Presentation.Controllers
{
    public class LoginController : AutenticaController
    {

        public ActionResult Logout()
        {
            Contexto.SignOut();

            Token = null;

            return RedirectToAction("Index");
        }


        // GET: Login
        public ActionResult Index()
        {
            try
            {
                if (Contexto.IsAuthentication())
                {
                    if (Contexto.Seguranca.Coligada == null && Contexto.Seguranca.Filial == null)
                        return RedirectToAction("Index", "Contexto");
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                throw ex;
                HandlingException(ex);
            }

            return View("Index");
        }

        // POST: Login
        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                Token = Contexto.Token(model.Usuario, model.Senha);

                Contexto.Reload();

                return RedirectToAction("Index");

                //if (_contexto.Seguranca.Coligada == null && _contexto.Seguranca.Filial == null || _contexto.Seguranca.TipoCurso == null)
                //    return RedirectToAction("Index", "Home");
                //return RedirectToAction("Index", "Contexto");
            }
            catch (Exception ex)
            {
                throw ex;
                HandlingException(ex);
            }

            return View("Index", model);
        }
    }
}