

using LVSA.Base.Application.Interfaces;
using LVSA.Base.Presentation.ViewModels;
using LVSA.Report.Application.Interfaces;
using LVSA.Report.Application.ViewModels;
using LVSA.Report.Presentation.Models;
using LVSA.Report.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Report.Presentation.Controllers
{
    public class CuboController : ControllerBase
    {
        private readonly IConsultaAppService _consultaAppService;
        private readonly IReadOnlyAppService _readOnlyAppService;
        private readonly IParametroAppService _parametroAppService;
        private readonly ICuboAppService _cuboAppService;
        private readonly IInstrucaoAppService _instrucaoAppService;
        private readonly ICategoriaCuboAppService _categoriaCuboAppService;

        public CuboController(ICuboAppService cuboAppService, ICategoriaCuboAppService categoriaCuboAppService, IInstrucaoAppService instrucaoAppService, IConsultaAppService consultaAppService, IReadOnlyAppService readOnlyAppService, IParametroAppService parametroAppService)
        {
            _cuboAppService = cuboAppService;
            _instrucaoAppService = instrucaoAppService;
            _consultaAppService = consultaAppService;
            _readOnlyAppService = readOnlyAppService;
            _parametroAppService = parametroAppService;
            _categoriaCuboAppService = categoriaCuboAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _cuboAppService.SetSeguranca(Contexto.Seguranca);
            _consultaAppService.SetSeguranca(Contexto.Seguranca);
            _parametroAppService.SetSeguranca(Contexto.Seguranca);
            _instrucaoAppService.SetSeguranca(Contexto.Seguranca);
            _categoriaCuboAppService.SetSeguranca(Contexto.Seguranca);

        }

        // GET: Cubo
        public ActionResult Index()
        {
            try
            {
                IEnumerable<CuboViewModel> model = _cuboAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Cubo/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                CuboViewModel model = _cuboAppService.ObterPorId(id);
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

        // GET: Cubo/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.InstrucaoSet = _instrucaoAppService.Filtrar(f => f.Ativo);
                ViewBag.ConsultaSet = _consultaAppService.Filtrar(f => f.Ativo);
                ViewBag.CategoriaCuboSet = _categoriaCuboAppService.Filtrar(f => f.Ativo);

                return View(new CuboAppViewModel());
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Cubo/Create
        [HttpPost]
        public ActionResult Create(CuboAppViewModel model, string test = null)
        {
            try
            {
                ModelState.Remove("Consulta.Codigo");
                ModelState.Remove("Consulta.Descricao");
                ModelState.Remove("Instrucao.Codigo");

                if (!ModelState.IsValid)
                {
                    ViewBag.InstrucaoSet = _instrucaoAppService.Filtrar(f => f.Ativo);
                    ViewBag.ConsultaSet = _consultaAppService.Filtrar(f => f.Ativo);
                    ViewBag.CategoriaCuboSet = _categoriaCuboAppService.Filtrar(f => f.Ativo);

                    if (model.Consulta != null)
                        foreach (var p in model.Consulta.Parametros)
                            p.ValorSet = _parametroAppService.ObterPorId(p.Id).ValorSet;

                    return View(model);
                }

                if (test != null)
                    return Test(model);


                if (model.Consulta == null || model.Instrucao == null || model.InstrucaoId != model.Instrucao.Id || model.ConsultaId != model.Consulta.Id)
                {
                    ConsultaViewModel consulta = _consultaAppService.ObterPorId(model.ConsultaId);
                    if (consulta == null)
                        throw new ArgumentException();

                    InstrucaoViewModel instrucao = _instrucaoAppService.ObterPorId(model.InstrucaoId);
                    if (instrucao == null)
                        throw new ArgumentException();

                    model.Consulta = consulta;
                    model.Instrucao = instrucao;
                    ViewBag.CategoriaCuboSet = _categoriaCuboAppService.Filtrar(f => f.Ativo);

                    return View(model);
                }

                model.Consulta = null;
                model.Instrucao = null;

                // TODO: Add insert logic here
                _cuboAppService.Incluir(model);

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

        [HttpGet]
        public ActionResult Test(CuboViewModel model)
        {
            try
            {
                ViewBag.InstrucaoSet = _instrucaoAppService.Filtrar(f => f.Ativo);
                ViewBag.ConsultaSet = _consultaAppService.Filtrar(f => f.Ativo);
                ViewBag.CategoriaCuboSet = _categoriaCuboAppService.Filtrar(f => f.Ativo);

                if (model.Consulta != null && model.Consulta.Parametros != null)
                    foreach (var p in model.Consulta.Parametros)
                        p.ValorSet = _parametroAppService.ObterPorId(p.Id).ValorSet;

                try
                {
                    ReportViewModel report = new ReportViewModel(_readOnlyAppService, Contexto.Seguranca);

                    if (model.Consulta != null && model.Consulta.Parametros != null)
                    {
                        foreach (var k in model.Consulta.Parametros)
                        {
                            if (k.Multivaloravel)
                                if (k.Valor is string[])
                                    k.Valor = string.Join(",", k.Valor);
                        }

                        report.Parametros = model.Consulta.Parametros;
                    }

                    report.TSQL = model.Consulta.TSQL;

                    ScriptHost hosting = new ScriptHost(report);

                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    hosting.Execute(model.Instrucao.Code);
                    sw.Stop();

                    foreach (var r in report.Gritters)
                        Gritters.Add(r);

                    model.Time = sw.Elapsed.TotalMilliseconds;
                    model.Rows = report.Rows;
                    model.ShowResult = true;

                    //if (!string.IsNullOrEmpty(report.View))
                    //    return View(report.View, report.Model);

                }
                catch (Exception exception)
                {
                    ModelState.AddModelError("ShowResult", exception.Message);
                }

                if (ModelState.IsValid)
                    Gritters.Add(new GritterViewModel
                    {
                        Tittle = "Sucesso!",
                        Message = "Testado com sucesso.",


                        Style = GritterStyle.Success,

                    });

                return View("Create", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: Cubo/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                CuboViewModel model = _cuboAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                ViewBag.CategoriaCuboSet = _categoriaCuboAppService.Filtrar(f => f.Ativo);

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Cubo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CuboViewModel model)
        {
            try
            {
                ModelState.Remove("Consulta.Codigo");
                ModelState.Remove("Consulta.TSQL");
                ModelState.Remove("Consulta.Descricao");
                ModelState.Remove("Instrucao.Codigo");
                ModelState.Remove("Instrucao.Code");

                if (!ModelState.IsValid)
                {
                    CuboViewModel original = _cuboAppService.ObterPorId(id);

                    model.Consulta = original.Consulta;
                    model.Instrucao = original.Instrucao;

                    ViewBag.CategoriaCuboSet = _categoriaCuboAppService.Filtrar(f => f.Ativo);
                    return View(model);
                }
                // TODO: Add update logic here
                _cuboAppService.Atualizar(model);

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

        // GET: Cubo/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                CuboViewModel model = _cuboAppService.ObterPorId(id);
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

        // POST: Cubo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CuboViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _cuboAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _cuboAppService.Remover(model);

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

        //
        // GET: Cubo/Execute/5
        public ActionResult Execute(int id)
        {
            try
            {
                CuboViewModel model = _cuboAppService.ObterPorId(id);
                if (model == null)
                    throw new ArgumentNullException();

                model.Consulta = _consultaAppService.ObterPorId(model.ConsultaId);

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }
            return RedirectToAction("Index");
        }

        //
        // POST: Cubo/Execute/5
        [HttpPost]
        public ActionResult Execute(int id, CuboViewModel model)
        {
            try
            {
                foreach (var key in ModelState.Keys.ToList().Where(k => k.Contains("Codigo") || k.Contains("TSQL") || k.Contains("Nome") || k.Contains("Descricao")))
                    ModelState[key].Errors.Clear();

                ReportViewModel report = new ReportViewModel(_readOnlyAppService, Contexto.Seguranca);

                if (model.Consulta != null && model.Consulta.Parametros != null)
                {
                    foreach (var k in model.Consulta.Parametros)
                    {
                        if (k.Multivaloravel)
                            if (k.Valor is string[])
                                k.Valor = string.Join(",", k.Valor);
                    }

                    report.Parametros = model.Consulta.Parametros;
                }

                if (!ModelState.IsValid)
                {
                    model = _cuboAppService.ObterPorId(id);
                    model.Consulta = _consultaAppService.ObterPorId(model.ConsultaId);

                    return View(model);
                }



                model = _cuboAppService.ObterPorId(id);

                if (model == null)
                    throw new ArgumentNullException();

                model.Consulta = _consultaAppService.ObterPorId(model.ConsultaId);
                model.Instrucao = _instrucaoAppService.ObterPorId(model.InstrucaoId);

                report.TSQL = model.Consulta.TSQL;

                ScriptHost hosting = new ScriptHost(report);

                Stopwatch sw = new Stopwatch();
                sw.Start();
                hosting.Execute(model.Instrucao.Code);
                sw.Stop();

                foreach (var r in report.Gritters)
                    Gritters.Add(r);

                model.Time = sw.Elapsed.TotalMilliseconds;
                model.Rows = report.Rows;
                model.ShowResult = true;

                if (!string.IsNullOrEmpty(report.View))
                    return View(report.View, report);

                return Report(report);



            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Execute", new { id = id });

        }


        //
        // POST: Cubo/Report
        [HttpPost]
        public ActionResult Report(ReportViewModel model)
        {
            return View("Report", model);
        }

        //
        // GET: Cubo/Run
        public ActionResult View()
        {
            try
            {
                //IEnumerable<CuboViewModel> model = SegurancaReport.Cubos;

                return View(CuboSet);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: Cubo/Execute/5
        public ActionResult Run(int id)
        {
            try
            {
                List<int> CuboIds = CuboSet.Select(s => s.Id).ToList();

                CuboViewModel model = _cuboAppService.Filtrar(f => f.Id == id && CuboIds.Contains(f.Id) && f.Ativo).SingleOrDefault();
                if (model == null)
                    throw new ArgumentNullException();

                model.Consulta = _consultaAppService.ObterPorId(model.ConsultaId);

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("View");
        }

        //
        // POST: Cubo/Run/5
        [HttpPost]
        public ActionResult Run(int id, CuboViewModel model)
        {
            try
            {
                foreach (var key in ModelState.Keys.ToList().Where(k => k.Contains("Codigo") || k.Contains("TSQL") || k.Contains("Nome") || k.Contains("Descricao")))
                    ModelState[key].Errors.Clear();

                ReportViewModel report = new ReportViewModel(_readOnlyAppService, Contexto.Seguranca);
                List<int> CuboIds = CuboSet.Select(s => s.Id).ToList();

                if (model.Consulta != null && model.Consulta.Parametros != null)
                {
                    foreach (var k in model.Consulta.Parametros)
                    {
                        if (k.Multivaloravel)
                            if (k.Valor is string[])
                                k.Valor = string.Join(",", k.Valor);
                    }
                    report.Parametros = model.Consulta.Parametros;
                }
                if (!ModelState.IsValid)
                {
                    model = _cuboAppService.Filtrar(f => f.Id == id && CuboIds.Contains(f.Id)).SingleOrDefault();
                    if (model == null)
                        throw new ArgumentNullException("model");
                    model.Consulta = _consultaAppService.ObterPorId(model.ConsultaId);
                    return View(model);
                }



                model = _cuboAppService.Filtrar(f => f.Id == id && CuboIds.Contains(f.Id)).SingleOrDefault();

                if (model == null)
                    throw new ArgumentNullException("model");

                model.Consulta = _consultaAppService.ObterPorId(model.ConsultaId);
                model.Instrucao = _instrucaoAppService.ObterPorId(model.InstrucaoId);

                report.TSQL = model.Consulta.TSQL;

                ScriptHost hosting = new ScriptHost(report);

                Stopwatch sw = new Stopwatch();
                sw.Start();
                hosting.Execute(model.Instrucao.Code);
                sw.Stop();

                foreach (var r in report.Gritters)
                    Gritters.Add(r);

                model.Time = sw.Elapsed.TotalMilliseconds;
                model.Rows = report.Rows;
                model.ShowResult = true;

                if (!string.IsNullOrEmpty(report.View))
                    return View(report.View, report);

                return Report(report);



            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }
    }
}
