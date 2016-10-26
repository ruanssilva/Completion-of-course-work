using LVSA.Base.Application.Exceptions;
using LVSA.Base.Presentation.ViewModels;
using LVSA.Global.Application.Interfaces;
using LVSA.Global.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Global.Presentation.Controllers
{
    public class EscolaridadeController : ControllerBase
    {
        private readonly IEscolaridadeAppService _escolaridadeAppService;

        public EscolaridadeController(IEscolaridadeAppService escolaridadeAppService)
        {
            _escolaridadeAppService = escolaridadeAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _escolaridadeAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: Escolaridade
        public ActionResult Index()
        {
            try
            {
                IEnumerable<EscolaridadeViewModel> model = _escolaridadeAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Escolaridade/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                EscolaridadeViewModel model = _escolaridadeAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
                if (model == null)
                    throw new NoRecordsFoundException("Registro não encontrado.");

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: Escolaridade/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Escolaridade/Create
        [HttpPost]
        public ActionResult Create(EscolaridadeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);
                
                _escolaridadeAppService.Incluir(model);

                Gritters.Add(new GritterViewModel
                {
                    Tittle = "Sucesso!",
                    Message = "Operação realizada com sucesso.",
                    Style = GritterStyle.Success,
                });

            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: Escolaridade/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                EscolaridadeViewModel model = _escolaridadeAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
                if (model == null)
                    throw new NoRecordsFoundException("Registro não encontrado.");

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Escolaridade/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EscolaridadeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);
                
                _escolaridadeAppService.Atualizar(model);

                Gritters.Add(new GritterViewModel
                {
                    Tittle = "Sucesso!",
                    Message = "Operação realizada com sucesso.",
                    Style = GritterStyle.Success,
                });
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: Escolaridade/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                EscolaridadeViewModel model = _escolaridadeAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
                if (model == null)
                    throw new NoRecordsFoundException("Registro não encontrado.");

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Escolaridade/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EscolaridadeViewModel model)
        {
            try
            {
                
                model = _escolaridadeAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _escolaridadeAppService.Remover(model);

                Gritters.Add(new GritterViewModel
                {
                    Tittle = "Sucesso!",
                    Message = "Operação realizada com sucesso.",
                    Style = GritterStyle.Success,
                });
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }
    }
}
