using LVSA.Base.Presentation.ViewModels;
using LVSA.Global.Application.Interfaces;
using LVSA.Global.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace LVSA.Global.Presentation.Controllers
{
    public class EmpresaController : ControllerBase
    {
        private readonly IPessoaJuridicaAppService _pessoaJuridicaAppService;
        private readonly ICidadeAppService _cidadeAppService;
        private readonly IBairroAppService _bairroAppService;

        public EmpresaController(IPessoaJuridicaAppService pessoaJuridicaAppService, ICidadeAppService cidadeAppService, IBairroAppService bairroAppService)
        {
            _pessoaJuridicaAppService = pessoaJuridicaAppService;
            _cidadeAppService = cidadeAppService;
            _bairroAppService = bairroAppService;            
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _pessoaJuridicaAppService.SetSeguranca(Contexto.Seguranca);

            ViewBag.CidadeSet = _cidadeAppService.Todos();
            ViewBag.BairroSet = _bairroAppService.Todos();
        }

        // GET: Empresa
        public ActionResult Index()
        {
            try
            {
                IEnumerable<PessoaJuridicaViewModel> model = _pessoaJuridicaAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Empresa/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                PessoaJuridicaViewModel model = _pessoaJuridicaAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
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

        // GET: Empresa/Create
        public ActionResult Create()
        {
            try
            {
                

                return View(new PessoaJuridicaViewModel());
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Empresa/Create
        [HttpPost]
        public ActionResult Create(PessoaJuridicaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {


                    return View(model);
                }
   
                _pessoaJuridicaAppService.Incluir(model);

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

        // GET: Empresa/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                PessoaJuridicaViewModel model = _pessoaJuridicaAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
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

        // POST: Empresa/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PessoaJuridicaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(model);
                }

                _pessoaJuridicaAppService.Atualizar(model);

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

        // GET: Empresa/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                PessoaJuridicaViewModel model = _pessoaJuridicaAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
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

        // POST: Empresa/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PessoaJuridicaViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _pessoaJuridicaAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _pessoaJuridicaAppService.Remover(model);

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
