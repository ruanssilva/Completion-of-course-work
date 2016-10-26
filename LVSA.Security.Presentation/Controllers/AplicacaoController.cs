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
    public class AplicacaoController : ControllerBase
    {
        private readonly IAplicacaoAppService _aplicacaoAppService;
        private readonly IParametroAppService _parametroAppService;

        public AplicacaoController(IAplicacaoAppService aplicacaoAppService, IParametroAppService parametroAppService)
        {
            _aplicacaoAppService = aplicacaoAppService;
            _parametroAppService = parametroAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _aplicacaoAppService.SetSeguranca(Contexto.Seguranca);
            _parametroAppService.SetSeguranca(Contexto.Seguranca);

            ViewBag.AplicacaoSet = _aplicacaoAppService.Filtrar(f => f.Ativo && f.Abstrata);
            ViewBag.ParametroSet = _parametroAppService.Filtrar(f => f.Ativo);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            AddShortcut("Ir para permissões", Url.Action("Grupo", "Permissao"), "fa fa-shield");
        }

        // GET: Aplicacao
        public ActionResult Index()
        {
            try
            {
                var aplicacaoset = _aplicacaoAppService.Todos();

                return View("Index", aplicacaoset);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Aplicacao/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var aplicacao = _aplicacaoAppService.ObterPorId(id);

                if (aplicacao == null)
                    throw new NoRecordsFoundException("Aplicação não encontrada");

                return View(aplicacao);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Aplicacao");
        }

        // GET: Aplicacao/Create
        public ActionResult Create()
        {
            try
            {
                return View(new AplicacaoViewModel { AplicacaoIdSet = new int[] { } });
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Aplicacao");
        }

        // POST: Aplicacao/Create
        [HttpPost]
        public ActionResult Create(AplicacaoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                _aplicacaoAppService.Incluir(model);

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

            return RedirectToAction("Index", "Aplicacao");
        }

        // GET: Aplicacao/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var aplicacao = _aplicacaoAppService.ObterPorId(id);

                if (aplicacao == null)
                    throw new NoRecordsFoundException("Aplicação não encontrada");

                return View(aplicacao);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Aplicacao");
        }

        // POST: Aplicacao/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AplicacaoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                _aplicacaoAppService.Atualizar(model);

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

            return RedirectToAction("Index", "Aplicacao");
        }

        // GET: Aplicacao/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var aplicacao = _aplicacaoAppService.ObterPorId(id);

                if (aplicacao == null)
                    throw new NoRecordsFoundException("Aplicação não encontrada");

                return View(aplicacao);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Aplicacao/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, AplicacaoViewModel model)
        {
            try
            {
                var aplicacao = _aplicacaoAppService.ObterPorId(id);
                if (aplicacao != null)
                {
                    _aplicacaoAppService.Remover(model);

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

        public ActionResult Parametros(int id)
        {
            try
            {
                var aplicacao = _aplicacaoAppService.ObterPorId(id);
                if (aplicacao == null)
                    throw new NoRecordsFoundException("Aplicação não encontrada");

                ViewBag.Aplicacao = aplicacao;

                return Index();
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Parametro(int aplicacao, string parametro = null)
        {
            try
            {
                var app = _aplicacaoAppService.ObterPorId(aplicacao);
                if (app == null)
                    throw new NoRecordsFoundException("Aplicação não encontrada");

                if (parametro != null)
                {
                    var param = app.ParametroSet.Where(w => w.Codigo == parametro).SingleOrDefault();
                    if (param != null)
                    {
                        _aplicacaoAppService.Desparametrizar(app, param);

                        Gritters.Add(new GritterViewModel
                        {
                            Tittle = "Sucesso!",
                            Message = "Operação realizada com sucesso.",
                            Style = GritterStyle.Success,
                        });
                    }

                    return RedirectToAction("Parametros", new { id = aplicacao });
                }
                else
                    ViewBag.Parametro = new ParametroViewModel
                    {
                        Sequencia = app.ParametroSet.Count() > 0 ? (short)(app.ParametroSet.Max(s => s.Sequencia) + 1) : (short)1
                    };

                return Parametros(aplicacao);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Parametros", new { id = aplicacao });
        }

        [HttpPost]
        public ActionResult Parametro(int aplicacao, ParametroViewModel model, string parametro = null)
        {
            try
            {
                foreach (var key in ModelState.Keys.ToList().Where(k => !(new string[] { "Codigo", "Exibicao", "Sequencia", "Obrigatorio", "Multi" }).Contains(k)))
                    ModelState[key].Errors.Clear();

                if (!ModelState.IsValid)
                    ViewBag.Parametro = model;
                else
                {
                    var app = _aplicacaoAppService.ObterPorId(aplicacao);
                    if (app == null)
                        throw new NoRecordsFoundException("Aplicação não encontrada");

                    _aplicacaoAppService.Parametrizar(app, model);

                    Gritters.Add(new GritterViewModel
                    {
                        Tittle = "Sucesso!",
                        Message = "Operação realizada com sucesso.",
                        Style = GritterStyle.Success,
                    });

                    return RedirectToAction("Parametros", new { id = aplicacao });
                }

                return Parametros(aplicacao);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }
    }
}
