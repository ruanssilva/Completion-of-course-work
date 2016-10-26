

using LVSA.Base.Application.Interfaces;
using LVSA.Base.Presentation.ViewModels;
using LVSA.Report.Application.Interfaces;
using LVSA.Report.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;


namespace LVSA.Report.Presentation.Controllers
{
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaAppService _consultaAppService;
        private readonly IReadOnlyAppService _readOnlyAppService;
        private readonly IParametroAppService _parametroAppService;
        private readonly ICategoriaConsultaAppService _categoriaConsultaAppService;

        public ConsultaController(IConsultaAppService consultaAppService, ICategoriaConsultaAppService categoriaConsultaAppService, IReadOnlyAppService readOnlyAppService, IParametroAppService parametroAppService)
        {
            _consultaAppService = consultaAppService;
            _readOnlyAppService = readOnlyAppService;
            _parametroAppService = parametroAppService;
            _categoriaConsultaAppService = categoriaConsultaAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _consultaAppService.SetSeguranca(Contexto.Seguranca);
            _parametroAppService.SetSeguranca(Contexto.Seguranca);
            _categoriaConsultaAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: Consulta
        public ActionResult Index()
        {
            try
            {
                IEnumerable<ConsultaViewModel> model = _consultaAppService.Todos();

                return View(model);
            }
            catch(Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Consulta/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                ConsultaViewModel model = _consultaAppService.ObterPorId(id);
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

        // GET: Consulta/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.CategoriaConsultaSet = _categoriaConsultaAppService.Filtrar(f => f.Ativo);

                return View(new ConsultaViewModel());
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Consulta/Create
        [HttpPost]
        public ActionResult Create(ConsultaViewModel model)
        {
            try
            {
                foreach (var key in ModelState.Keys.ToList().Where(k => (k.Contains("Parametros") && k.Contains("Codigo")) || (k.Contains("Parametros") && k.Contains("Nome"))))
                    ModelState[key].Errors.Clear();

                model.Parametros = model.Parametros ?? new List<ParametroViewModel>();

                var result = Regex.Matches(model.TSQL, @"{\d{1,5}}")
                                .Cast<Match>()
                                .Select(m =>
                                    Convert.ToInt32(m.Value.Replace("{", "").Replace("}", ""))
                                )
                                .Distinct()
                                .ToArray();

                if (result.Count() > 0 && result.Count() != model.Parametros.Count())
                {
                    if (model.Parametros.Count() != result.Count())
                    {
                        model.Parametros.Clear();

                        foreach (var p in result)
                        {
                            model.Parametros.Add(new ParametroViewModel
                            {
                                Numero = p
                            });
                        }

                        //limpando os erros de modelo
                        ModelState.Clear();

                        ViewBag.CategoriaConsultaSet = _categoriaConsultaAppService.Filtrar(f => f.Ativo);
                        ViewBag.ParametroSet = _parametroAppService.Todos();

                        return View(model);
                    }
                }

                if (!ModelState.IsValid)
                {
                    ViewBag.CategoriaConsultaSet = _categoriaConsultaAppService.Filtrar(f => f.Ativo);
                    ViewBag.ParametroSet = _parametroAppService.Todos();
                    return View(model);
                }

                // TODO: Add insert logic here
                model = _consultaAppService.Incluir(model);


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

        // GET: Consulta/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ConsultaViewModel model = _consultaAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                ViewBag.CategoriaConsultaSet = _categoriaConsultaAppService.Filtrar(f => f.Ativo);
                ViewBag.ParametroSet = _parametroAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Consulta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ConsultaViewModel model)
        {
            try
            {
                foreach (var key in ModelState.Keys.ToList().Where(k => (k.Contains("Parametros") && k.Contains("Codigo")) || (k.Contains("Parametros") && k.Contains("Nome"))))
                    ModelState[key].Errors.Clear();

                model.Parametros = model.Parametros ?? new List<ParametroViewModel>();

                var result = Regex.Matches(model.TSQL, @"{\d{1,5}}")
                                .Cast<Match>()
                                .Select(m =>
                                    Convert.ToInt32(m.Value.Replace("{", "").Replace("}", ""))
                                )
                                .Distinct()
                                .ToArray();

                model.Parametros = result.Count() == 0 ? new List<ParametroViewModel> { } : model.Parametros;

                if (result.Count() > 0 && result.Count() != model.Parametros.Count())
                {
                    if (model.Parametros.Count() != result.Count())
                    {
                        //para retonar os nomes ja preenchidos do usuário
                        List<ParametroViewModel> aux = new List<ParametroViewModel> { };

                        //model.Parametros.Clear();

                        foreach (var p in result)
                        {
                            aux.Add(new ParametroViewModel
                            {
                                Id = model.Parametros.Where(w => w.Numero == p).Select(s => s.Id).FirstOrDefault(),
                                Descricao = model.Parametros.Where(w => w.Numero == p).Select(s => s.Descricao).FirstOrDefault(),
                                Numero = p
                            });
                        }

                        model.Parametros = aux;

                        //limpando os erros de modelo
                        ModelState.Clear();

                        ViewBag.CategoriaConsultaSet = _categoriaConsultaAppService.Filtrar(f => f.Ativo);
                        ViewBag.ParametroSet = _parametroAppService.Todos();

                        return View(model);
                    }
                }

                if (!ModelState.IsValid)
                {
                    ViewBag.CategoriaConsultaSet = _categoriaConsultaAppService.Filtrar(f => f.Ativo);
                    ViewBag.ParametroSet = _parametroAppService.Todos();
                    return View(model);
                }

                // TODO: Add update logic here
                _consultaAppService.Atualizar(model);

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

        // GET: Consulta/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ConsultaViewModel model = _consultaAppService.ObterPorId(id);
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

        // POST: Consulta/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ConsultaViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _consultaAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _consultaAppService.Remover(model);

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
