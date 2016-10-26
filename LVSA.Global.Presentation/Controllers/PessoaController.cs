using LVSA.Base.Presentation.ViewModels;
using LVSA.Global.Application.Interfaces;
using LVSA.Global.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Global.Presentation.Controllers
{
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaFisicaAppService _pessoaFisicaAppService;
        private readonly IBairroAppService _bairroAppService;
        private readonly ICidadeAppService _cidadeAppService;

        public PessoaController(IPessoaFisicaAppService pessoaFisicaAppService, IBairroAppService bairroAppService, ICidadeAppService cidadeAppService)
        {
            _pessoaFisicaAppService = pessoaFisicaAppService;
            _bairroAppService = bairroAppService;
            _cidadeAppService = cidadeAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Contexto.IsAuthentication())
            {
                _pessoaFisicaAppService.SetSeguranca(Contexto.Seguranca);
                _bairroAppService.SetSeguranca(Contexto.Seguranca);
                _cidadeAppService.SetSeguranca(Contexto.Seguranca);

                ViewBag.CidadeSet = _cidadeAppService.Todos();
                ViewBag.BairroSet = _bairroAppService.Todos();
            }
        }

        // GET: Pessoa
        public ActionResult Index()
        {
            try
            {
                IEnumerable<PessoaFisicaViewModel> model = _pessoaFisicaAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                PessoaFisicaViewModel model = _pessoaFisicaAppService.Filtrar(f => f.Id == id).SingleOrDefault();
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

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            try
            {


                return View(new PessoaFisicaViewModel());
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Pessoa/Create
        [HttpPost]
        public ActionResult Create(PessoaFisicaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(model);
                }

                _pessoaFisicaAppService.Incluir(model);

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

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                PessoaFisicaViewModel model = _pessoaFisicaAppService.Filtrar(f => f.Id == id).SingleOrDefault();
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

        // POST: Pessoa/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PessoaFisicaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(model);
                }

                _pessoaFisicaAppService.Atualizar(model);

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

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                PessoaFisicaViewModel model = _pessoaFisicaAppService.Filtrar(f => f.Id == id).SingleOrDefault();
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

        // POST: Pessoa/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PessoaFisicaViewModel model)
        {
            try
            {

                model = _pessoaFisicaAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _pessoaFisicaAppService.Remover(model);

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
