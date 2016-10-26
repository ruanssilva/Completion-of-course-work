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
    public class ParametroController : ControllerBase
    {
        private readonly IParametroAppService _parametroAppService;

        public ParametroController(IParametroAppService parametroAppService)
        {
            _parametroAppService = parametroAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _parametroAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: Parametro
        public ActionResult Index()
        {
            try
            {
                return View("Index", _parametroAppService.Todos());
            }
            catch(Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Parametro/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var parametro = _parametroAppService.ObterPorId(id);
                if (parametro == null)
                    throw new NoRecordsFoundException("Parâmetro não encontrado");

                return View("Details", parametro);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: Parametro/Create
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

        // POST: Parametro/Create
        [HttpPost]
        public ActionResult Create(ParametroViewModel model)
        {
            try
            {
                foreach (var key in ModelState.Keys.ToList().Where(k => !(new string[] { "Nome", "Descricao", "Type", "Ativo", "TSQLAtivo", "TSQL", "Mascara", "Regex" }).Contains(k)))
                    ModelState[key].Errors.Clear();

                if (!ModelState.IsValid)
                    return View("Create", model);

                _parametroAppService.Incluir(model);

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

        // GET: Parametro/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var parametro = _parametroAppService.ObterPorId(id);
                if (parametro == null)
                    throw new NoRecordsFoundException("Parâmetro não encontrado");

                return View("Edit", parametro);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Parametro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ParametroViewModel model)
        {
            try
            {
                foreach (var key in ModelState.Keys.ToList().Where(k => !(new string[] { "Nome", "Descricao", "Type", "Ativo", "TSQLAtivo", "TSQL", "Mascara", "Regex" }).Contains(k)))
                    ModelState[key].Errors.Clear();

                if (!ModelState.IsValid)
                    return View("Edit", model);

                _parametroAppService.Atualizar(model);

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

        // GET: Parametro/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var parametro = _parametroAppService.ObterPorId(id);
                if (parametro == null)
                    throw new NoRecordsFoundException("Parâmetro não encontrado");

                return View("Delete", parametro);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Parametro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ParametroViewModel model)
        {
            try
            {
                var parametro = _parametroAppService.ObterPorId(id);
                if (parametro != null)
                {
                    _parametroAppService.Remover(model);

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
