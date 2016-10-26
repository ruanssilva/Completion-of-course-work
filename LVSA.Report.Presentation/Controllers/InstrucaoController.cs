

using LVSA.Base.Application.Interfaces;
using LVSA.Base.Presentation.ViewModels;
using LVSA.Report.Application.Interfaces;
using LVSA.Report.Application.ViewModels;
using LVSA.Report.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Report.Presentation.Controllers
{
    public class InstrucaoController : ControllerBase
    {
        private readonly IConsultaAppService _consultaAppService;
        private readonly IReadOnlyAppService _readOnlyAppService;
        private readonly IInstrucaoAppService _instrucaoAppService;
        private readonly ICategoriaInstrucaoAppService _categoriaInstrucaoAppService;


        public InstrucaoController(IConsultaAppService consultaAppService, ICategoriaInstrucaoAppService categoriaInstrucaoAppService, IReadOnlyAppService readOnlyAppService, IInstrucaoAppService instrucaoAppService)
        {
            _consultaAppService = consultaAppService;
            _readOnlyAppService = readOnlyAppService;
            _instrucaoAppService = instrucaoAppService;
            _categoriaInstrucaoAppService = categoriaInstrucaoAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _consultaAppService.SetSeguranca(Contexto.Seguranca);
            _instrucaoAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: Instrucao
        public ActionResult Index()
        {
            try
            {
                IEnumerable<InstrucaoViewModel> model = _instrucaoAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Instrucao/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                InstrucaoViewModel model = _instrucaoAppService.ObterPorId(id);
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

        // GET: Instrucao/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.CategoriaInstrucaoSet = _categoriaInstrucaoAppService.Filtrar(f => f.Ativo);

                return View(new InstrucaoAppViewModel());
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Instrucao/Create
        [HttpPost]
        public ActionResult Create(InstrucaoAppViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.CategoriaInstrucaoSet = _categoriaInstrucaoAppService.Filtrar(f => f.Ativo);
                    return View(model);
                }
                    
                // TODO: Add insert logic here
                _instrucaoAppService.Incluir(model);

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

        // GET: Instrucao/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                InstrucaoAppViewModel model = new InstrucaoAppViewModel(_instrucaoAppService.ObterPorId(id));
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                ViewBag.CategoriaInstrucaoSet = _categoriaInstrucaoAppService.Filtrar(f => f.Ativo);

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Instrucao/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, InstrucaoAppViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.CategoriaInstrucaoSet = _categoriaInstrucaoAppService.Filtrar(f => f.Ativo);
                    return View(model);
                }
                // TODO: Add update logic here
                _instrucaoAppService.Atualizar(model);

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

        // GET: Instrucao/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                InstrucaoViewModel model = _instrucaoAppService.ObterPorId(id);
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

        // POST: Instrucao/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, InstrucaoViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _instrucaoAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _instrucaoAppService.Remover(model);

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
