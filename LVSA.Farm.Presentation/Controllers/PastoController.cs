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
    public class PastoController : ControllerBase
    {
        private readonly IPastoAppService _pastoAppService;

        public PastoController(IPastoAppService pastoAppService)
        {
            _pastoAppService = pastoAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Contexto.IsAuthentication())
            {
                _pastoAppService.SetSeguranca(Contexto.Seguranca);
            }
        }

        // GET: Pasto
        public ActionResult Index()
        {
            try
            {
                var model = _pastoAppService.Todos();

                return View("Index", model);
            }
            catch(Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Pasto/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var model = _pastoAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if (model == null)
                    throw new NoRecordsFoundException("Pasto não encontrado");

                return View("Details", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: Pasto/Create
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

        // POST: Pasto/Create
        [HttpPost]
        public ActionResult Create(PastoViewModel model, HttpPostedFileBase[] FileSet)
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

                _pastoAppService.Incluir(model);

                Gritters.Add(new GritterViewModel
                {
                    Tittle = "Sucesso!",
                    Message = "Operação realizada com sucesso.",
                    Style = GritterStyle.Success,
                });

            }
            catch(Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: Pasto/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var model = _pastoAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if (model == null)
                    throw new NoRecordsFoundException("Pasto não encontrado");

                return View("Edit", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Pasto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PastoViewModel model, HttpPostedFileBase[] FileSet)
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

                _pastoAppService.Atualizar(model);

                Gritters.Add(new GritterViewModel
                {
                    Tittle = "Sucesso!",
                    Message = "Operação realizada com sucesso.",
                    Style = GritterStyle.Success,
                });
               
            }
            catch(Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: Pasto/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var model = _pastoAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if (model == null)
                    throw new NoRecordsFoundException("Registro não encontrado");

                return View("Delete", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Pasto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PastoViewModel model)
        {
            try
            {
                var _model = _pastoAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if (_model == null)
                    throw new NoRecordsFoundException("Registro não encontrado");

                _pastoAppService.Remover(model);

                Gritters.Add(new GritterViewModel
                {
                    Tittle = "Sucesso!",
                    Message = "Operação realizada com sucesso.",
                    Style = GritterStyle.Success,
                });
            }
            catch(Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }
    }
}
