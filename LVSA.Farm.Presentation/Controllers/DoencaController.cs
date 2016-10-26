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
    public class DoencaController : ControllerBase
    {
        private readonly IDoencaAppService _doencaAppService;
        public DoencaController(IDoencaAppService DoencaAppService)
        {
            _doencaAppService = DoencaAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Contexto.IsAuthentication())
            {
                _doencaAppService.SetSeguranca(Contexto.Seguranca);
            }
        }

        // GET: Doenca
        public ActionResult Index()
        {
            try
            {
                var model = _doencaAppService.Todos();
                return View("Index", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Doenca/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var model = _doencaAppService.Filtrar(f => f.Id == id).SingleOrDefault();
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

        // GET: Doenca/Create
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

        // POST: Doenca/Create
        [HttpPost]
        public ActionResult Create(DoencaViewModel model, HttpPostedFileBase[] FileSet)
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

                _doencaAppService.Incluir(model);

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

        // GET: Doenca/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var model = _doencaAppService.Filtrar(f => f.Id == id).SingleOrDefault();
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

        // POST: Doenca/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DoencaViewModel model, HttpPostedFileBase[] FileSet)
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


                _doencaAppService.Atualizar(model);

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

        // GET: Doenca/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var model = _doencaAppService.Filtrar(f => f.Id == id).SingleOrDefault();
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

        // POST: Doenca/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DoencaViewModel model)
        {
            try
            {
                var _model = _doencaAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if(_model == null)
                    throw new NoRecordsFoundException("Registro não encontrado");

                _doencaAppService.Remover(model);

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