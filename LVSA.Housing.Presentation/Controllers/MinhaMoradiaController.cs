

using LVSA.Base.Presentation.ViewModels;
using LVSA.Housing.Application.Interfaces;
using LVSA.Housing.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Housing.Presentation.Controllers
{
    public class MinhaMoradiaController : MoradorControllerBase
    {
        private readonly IMoradiaAppService _moradiaAppService;

        public MinhaMoradiaController(IMoradiaAppService moradiaAppService)
        {
            _moradiaAppService = moradiaAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _moradiaAppService.SetSeguranca(Contexto.Seguranca);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (Morador == null)
            {
                

                Gritters.Add(new GritterViewModel
                {
                    Tittle = "Você não é um morador!",
                    Message = "Essa área no sistema é exclusiva para moradores, procure o administrador para mais informações.",
                    Style = GritterStyle.Warning,
                    Center = true
                });

                filterContext.Result = RedirectToAction("Index", "Home");
            }
        }

        // GET: MinhaMoradia
        public ActionResult Index()
        {
            return RedirectToAction("Details");
        }

        // GET: MinhaMoradia/Details/5
        public ActionResult Details()
        {
            try
            {
                MoradiaViewModel model = _moradiaAppService.Filtrar(f => f.Moradores.Where(w => w.PessoaId == Morador.Pessoa.Id).Count() > 0).SingleOrDefault();
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }


        // GET: MinhaMoradia/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MinhaMoradia/Edit/5
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
    }
}
