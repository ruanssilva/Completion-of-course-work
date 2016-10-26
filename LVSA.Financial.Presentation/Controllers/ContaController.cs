using LVSA.Base.Presentation.ViewModels;
using LVSA.Financial.Application.Interfaces;
using LVSA.Financial.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Financial.Presentation.Controllers
{
    public class ContaController : ControllerBase
    {
        private readonly IContaAppService _contaAppService;
        private readonly ITipoContaAppService _tipoContaAppService;

        public ContaController(IContaAppService ContaAppService, ITipoContaAppService tipoContaAppService)
        {
            _contaAppService = ContaAppService;
            _tipoContaAppService = tipoContaAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            
            _contaAppService.SetSeguranca(Contexto.Seguranca);
            _tipoContaAppService.SetSeguranca(Contexto.Seguranca);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (Contexto.IsAuthentication())
            {
                ViewBag.TipoContaSet = _tipoContaAppService.Filtrar(f => f.Ativo);
            }
        }

        // GET: Conta
        public ActionResult Index()
        {
            try
            {
                IEnumerable<ContaViewModel> model = _contaAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Conta/Details/5
        public ActionResult Details(short id)
        {
            try
            {
                ContaViewModel model = _contaAppService.ObterPorId(id);
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

        // GET: Conta/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Conta/Create
        [HttpPost]
        public ActionResult Create(ContaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                // TODO: Add insert logic here
                _contaAppService.Incluir(model);

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

        // GET: Conta/Edit/5
        public ActionResult Edit(short id)
        {
            try
            {
                ContaViewModel model = _contaAppService.ObterPorId(id);
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

        // POST: Conta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ContaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                // TODO: Add update logic here
                _contaAppService.Atualizar(model);

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

        // GET: Conta/Delete/5
        public ActionResult Delete(short id)
        {
            try
            {
                ContaViewModel model = _contaAppService.ObterPorId(id);
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

        // POST: Conta/Delete/5
        [HttpPost]
        public ActionResult Delete(short id, ContaViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _contaAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _contaAppService.Remover(model);

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
