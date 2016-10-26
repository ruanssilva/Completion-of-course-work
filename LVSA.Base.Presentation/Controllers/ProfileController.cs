using LVSA.Base.Presentation.Rest;
using LVSA.Base.Presentation.ViewModels;
using LVSA.Security.Application.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Base.Presentation.Controllers
{
    public class ProfileController : AutenticaController
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public ProfileController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Contexto.IsAuthentication())
            {
                _usuarioAppService.SetSeguranca(Contexto.Seguranca);
            }
        }

        // GET: Profile
        public ActionResult Index()
        {
            try
            {


            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(ProfileViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);
                
                if (!string.IsNullOrWhiteSpace(model.OldPassword) || !string.IsNullOrWhiteSpace(model.NewPassword) || !string.IsNullOrWhiteSpace(model.ConfirmPassword))
                {

                    if (model.NewPassword != model.ConfirmPassword)
                        ModelState.AddModelError("ConfirmPassword", "As senha digitadas não conferem");
                    else
                    {
                        string result = Contexto.Password(model.OldPassword, model.NewPassword, model.ConfirmPassword);
                        if (!string.IsNullOrEmpty(result))
                        {
                            if (result.Contains("Incorrect password."))
                                ModelState.AddModelError("OldPassword", "Senha incorreta");
                            else
                                ModelState.AddModelError("OldPassword", "Ops! Não foi possível alterar sua senha. Tente novamente mais tarde.");

                            Gritters.Add(new GritterViewModel
                            {
                                Tittle = "Ops! Algo deu errado",
                                Message = "Não foi possível alterar sua senha, tente novamente.",
                                Style = GritterStyle.Warning,
                                Sticky = true
                            });
                        }
                        else
                        {

                        }
                    }
                }

                if (model.File != null)
                {
                    MemoryStream target = new MemoryStream();
                    model.File.InputStream.CopyTo(target);

                    _usuarioAppService.AtualizarAvatar(target.ToArray());

                    Contexto.Seguranca.Usuario.Avatar = target.ToArray();
                }

            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return View();
        }

        // GET: Profile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Profile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profile/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
