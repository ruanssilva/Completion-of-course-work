using LVSA.Base.Application.Exceptions;
using LVSA.Base.Presentation.ViewModels;
using LVSA.Farm.Application.Interfaces;
using LVSA.Farm.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Farm.Presentation.Controllers
{
    public class DiagnosticoController : ControllerBase
    {
        private readonly IDiagnosticoAppService _diagnosticoAppService;
        private readonly IAnimalAppService _animalAppService;
        private readonly IDoencaAppService _doencaAppService;
        public DiagnosticoController(IDiagnosticoAppService diagnosticoAppService, IAnimalAppService animalAppService, IDoencaAppService doencaAppService)
        {
            _diagnosticoAppService = diagnosticoAppService;
            _animalAppService = animalAppService;
            _doencaAppService = doencaAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Contexto.IsAuthentication())
            {
                _diagnosticoAppService.SetSeguranca(Contexto.Seguranca);
                _animalAppService.SetSeguranca(Contexto.Seguranca);
                _doencaAppService.SetSeguranca(Contexto.Seguranca);
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            ViewBag.AnimalSet = _animalAppService.Todos();
            ViewBag.DoencaSet = _doencaAppService.Filtrar(f => f.Ativo);
        }

        // GET: Diagnostico
        public ActionResult Index()
        {
            try
            {
                var model = _diagnosticoAppService.Todos();

                return View("Index", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Diagnostico/Details/5
        public ActionResult Details(long id)
        {
            try
            {
                var model = _diagnosticoAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if (model == null)
                    throw new NoRecordsFoundException("Diagnostico não encontrado");

                return View("Details", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: Diagnostico/Create
        public ActionResult Create()
        {
            try
            {
                return View("Create");
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Diagnostico/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DiagnosticoViewModel model, HttpPostedFileBase[] FileSet)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Create", model);

                if (FileSet != null && FileSet.Count() > 0)
                {
                    List<RetratoViewModel> retratos = new List<RetratoViewModel>();
                    foreach (var f in FileSet)
                    {
                        if (f != null)
                        {
                            MemoryStream target = new MemoryStream();
                            f.InputStream.CopyTo(target);


                            retratos.Add(new RetratoViewModel
                            {
                                Valor = target.ToArray()
                            });

                            model.RetratoSet = retratos;
                        }
                    }
                }

                _diagnosticoAppService.Incluir(model);

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

        // GET: Diagnostico/Edit/5
        public ActionResult Edit(long id)
        {
            try
            {
                var model = _diagnosticoAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if (model == null)
                    throw new NoRecordsFoundException("Diagnostico não encontrado");

                return View("Edit", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Diagnostico/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(long id, DiagnosticoViewModel model, HttpPostedFileBase[] FileSet)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Edit", model);

                model.RetratoSet = model.RetratoSet != null ? model.RetratoSet.Where(w => w.Id > 0) : new List<RetratoViewModel> { };

                if (FileSet != null && FileSet.Count() > 0)
                {
                    List<RetratoViewModel> retratos = new List<RetratoViewModel>();
                    foreach (var f in FileSet)
                    {
                        if (f != null)
                        {
                            MemoryStream target = new MemoryStream();
                            f.InputStream.CopyTo(target);


                            retratos.Add(new RetratoViewModel
                            {
                                Valor = target.ToArray(),
                            });

                        }
                    }

                    model.RetratoSet = model.RetratoSet.Union(retratos);
                }


                _diagnosticoAppService.Atualizar(model);

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

        // GET: Diagnostico/Delete/5
        public ActionResult Delete(long id)
        {
            try
            {
                var model = _diagnosticoAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if (model == null)
                    throw new NoRecordsFoundException("Diagnostico não encontrado");

                return View("Delete", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Diagnostico/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DiagnosticoViewModel model)
        {
            try
            {
                var _model = _diagnosticoAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if (_model == null)
                    throw new NoRecordsFoundException("Diagnostico não encontrado");

                _diagnosticoAppService.Remover(model);

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
