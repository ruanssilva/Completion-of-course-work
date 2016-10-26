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
    public class RacaController : ControllerBase
    {
        private readonly IRacaAppService _RacaAppService;
        private readonly ITipoAnimalAppService _tipoAnimalAppService;
        private readonly IRetratoAppService _retratoAppService;
        public RacaController(IRacaAppService RacaAppService, ITipoAnimalAppService tipoAnimalAppService, IRetratoAppService retratoAppService)
        {
            _RacaAppService = RacaAppService;
            _tipoAnimalAppService = tipoAnimalAppService;
            _retratoAppService = retratoAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Contexto.IsAuthentication())
            {
                _RacaAppService.SetSeguranca(Contexto.Seguranca);
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            ViewBag.TipoAnimalSet = _tipoAnimalAppService.Filtrar(f => f.Ativo);
        }

        // GET: Raca
        public ActionResult Index()
        {
            try
            {
                var model = _RacaAppService.Todos();
                return View("Index", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Raca/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var model = _RacaAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if (model == null)
                    throw new NoRecordsFoundException("Registro não encontrado");

                return View("Details", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Raca/Create
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

        // POST: Raca/Create
        [HttpPost]
        public ActionResult Create(RacaViewModel model, HttpPostedFileBase[] FileSet)
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

                _RacaAppService.Incluir(model);

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

        // GET: Raca/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var model = _RacaAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if (model == null)
                    throw new NoRecordsFoundException("Registro não encontrado");

                return View("Edit", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST: Raca/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RacaViewModel model, HttpPostedFileBase[] FileSet)
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
                                Valor = target.ToArray()
                            });

                        }
                    }

                    model.RetratoSet = model.RetratoSet.Union(retratos);
                }

                

                _RacaAppService.Atualizar(model);

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

        // GET: Raca/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var model = _RacaAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if (model == null)
                    throw new NoRecordsFoundException("Registro não encontrado");

                return View("Delete", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST: Raca/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RacaViewModel model)
        {
            try
            {
                var _model = _RacaAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if (_model == null)
                    throw new NoRecordsFoundException("Registro não encontrado");

                _RacaAppService.Remover(model);

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
