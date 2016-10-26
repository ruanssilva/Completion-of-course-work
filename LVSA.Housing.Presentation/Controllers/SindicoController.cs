

using LVSA.Base.Presentation.ViewModels;
using LVSA.Global.Application.Interfaces;
using LVSA.Housing.Application.Interfaces;
using LVSA.Housing.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Housing.Presentation.Controllers
{
    public class SindicoController : ControllerBase
    {
        private readonly IPessoaFisicaAppService _pessoaFisicaAppService;
        private readonly ISindicoAppService _sindicoAppService;

        public SindicoController(IPessoaFisicaAppService pessoaFisicaAppService, ISindicoAppService sindicoAppService)
        {
            _pessoaFisicaAppService = pessoaFisicaAppService;
            _sindicoAppService = sindicoAppService;
        }
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _pessoaFisicaAppService.SetSeguranca(Contexto.Seguranca);
            _sindicoAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: Sindico
        public ActionResult Index()
        {
            try
            {
                IEnumerable<SindicoViewModel> model = _sindicoAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Sindico/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                SindicoViewModel model = _sindicoAppService.ObterPorId(id);
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

        // GET: Sindico/Create
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

        // POST: Sindico/Create
        [HttpPost]
        public ActionResult Create(SindicoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);
                // TODO: Add insert logic here
                _sindicoAppService.Incluir(model);

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

        // GET: Sindico/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                SindicoViewModel model = _sindicoAppService.ObterPorId(id);
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

        // POST: Sindico/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SindicoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);
                // TODO: Add update logic here
                _sindicoAppService.Atualizar(model);

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

        // GET: Sindico/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                SindicoViewModel model = _sindicoAppService.ObterPorId(id);
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

        // POST: Sindico/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SindicoViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _sindicoAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _sindicoAppService.Remover(model);

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

        // POST: Sindico/Pessoa
        [HttpPost]
        public ActionResult Pessoa(SindicoViewModel model)
        {
            try
            {
                if (model.PessoaId > 0)
                {
                    model.Pessoa = _pessoaFisicaAppService.ObterPorId(model.PessoaId);
                    if (model.Pessoa == null)
                        throw new KeyNotFoundException();

                    return View("Create", model);
                }

                if (!string.IsNullOrEmpty(model.Pessoa.Nome))
                {
                    //Obter os PessoaId que já estão como Sindicos para o condominio atual para não trazer na pesquisa de novo
                    IEnumerable<int> SaoSindicos = _sindicoAppService.Todos().Select(s => s.PessoaId).ToList();

                    ViewBag.PessoaSet = _pessoaFisicaAppService.Filtrar(f => !SaoSindicos.Contains(f.Id) && f.Nome.ToLower().Contains(model.Pessoa.Nome.ToLower()));
                }

                return View("Create", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }


            return RedirectToAction("Index");
        }


    }
}
