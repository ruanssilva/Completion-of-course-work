using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LVSA.Base.Application.Exceptions;
using LVSA.Base.Presentation.ViewModels;
using LVSA.Security.Application.Interfaces;
using LVSA.Security.Application.ViewModels;

namespace LVSA.Security.Presentation.Controllers
{
    public class TipoRecursoController : ControllerBase
    {
        private readonly ITipoRecursoAppService _tipoRecursoAppService;

        public TipoRecursoController(ITipoRecursoAppService tipoRecursoAppService)
        {
            _tipoRecursoAppService = tipoRecursoAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _tipoRecursoAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: TipoRecurso
        public ActionResult Index()
        {
            try
            {
                var tiporecursoset = _tipoRecursoAppService.Todos();

                return View("Index", tiporecursoset);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: TipoRecurso/Details/5
        public ActionResult Details(short id)
        {
            try
            {
                var tiporecurso = _tipoRecursoAppService.ObterPorId(id);

                if (tiporecurso == null)
                    throw new NoRecordsFoundException("Tipo recurso não encontrado");

                return View("Details", tiporecurso);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: TipoRecurso/Create
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

        // POST: TipoRecurso/Create
        [HttpPost]
        public ActionResult Create(TipoRecursoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                _tipoRecursoAppService.Incluir(model);

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

        // GET: TipoRecurso/Edit/5
        public ActionResult Edit(short id)
        {
            try
            {
                var tiporecurso = _tipoRecursoAppService.ObterPorId(id);

                if (tiporecurso == null)
                    throw new NoRecordsFoundException("Tipo recurso não encontrado");

                return View("Edit", tiporecurso);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: TipoRecurso/Edit/5
        [HttpPost]
        public ActionResult Edit(short id, TipoRecursoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                _tipoRecursoAppService.Atualizar(model);

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

        // GET: TipoRecurso/Delete/5
        public ActionResult Delete(short id)
        {
            try
            {
                var tiporecurso = _tipoRecursoAppService.ObterPorId(id);

                if (tiporecurso == null)
                    throw new NoRecordsFoundException("Tipo recurso não encontrado");

                return View("Delete", tiporecurso);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: TipoRecurso/Delete/5
        [HttpPost]
        public ActionResult Delete(short id, TipoRecursoViewModel model)
        {
            try
            {
                var aplicacao = _tipoRecursoAppService.ObterPorId(id);
                if (aplicacao != null)
                {
                    _tipoRecursoAppService.Remover(model);

                    Gritters.Add(new GritterViewModel
                    {
                        Tittle = "Sucesso!",
                        Message = "Operação realizada com sucesso.",
                        Style = GritterStyle.Success,
                    });
                }
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }
    }
}
