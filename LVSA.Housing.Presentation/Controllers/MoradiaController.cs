

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
    public class MoradiaController : ControllerBase
    {
        private readonly IMoradiaAppService _moradiaAppService;
        private readonly IMoradorAppService _moradorAppService;
        private readonly IBlocoAppService _blocoAppService;
        private readonly IPessoaFisicaAppService _pessoaFisicaAppService;

        public MoradiaController(IMoradiaAppService moradiaAppService, IBlocoAppService blocoAppService, IPessoaFisicaAppService pessoaFisicaAppService, IMoradorAppService moradorAppService)
        {
            _moradiaAppService = moradiaAppService;
            _blocoAppService = blocoAppService;
            _pessoaFisicaAppService = pessoaFisicaAppService;
            _moradorAppService = moradorAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _moradiaAppService.SetSeguranca(Contexto.Seguranca);
            _blocoAppService.SetSeguranca(Contexto.Seguranca);
            _pessoaFisicaAppService.SetSeguranca(Contexto.Seguranca);
            _moradorAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: Moradia
        public ActionResult Index()
        {
            try
            {
                IEnumerable<MoradiaViewModel> model = _moradiaAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }
               

        // GET: Moradia/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                MoradiaViewModel model = _moradiaAppService.ObterPorId(id);
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

        // GET: Moradia/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.BlocoSet = _blocoAppService.Filtrar(f => f.Ativo);

                return View(new MoradiaViewModel());
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Moradia/Create
        [HttpPost]
        public ActionResult Create(MoradiaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.BlocoSet = _blocoAppService.Filtrar(f => f.Ativo);

                    return View(model);
                }

                // TODO: Add insert logic here
                _moradiaAppService.Incluir(model);

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

        // GET: Moradia/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                MoradiaViewModel model = _moradiaAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                ViewBag.BlocoSet = _blocoAppService.Filtrar(f => f.Ativo);

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Moradia/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MoradiaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.BlocoSet = _blocoAppService.Filtrar(f => f.Ativo);

                    return View(model);
                }

                // TODO: Add update logic here
                _moradiaAppService.Atualizar(model);

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

        // GET: Moradia/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                MoradiaViewModel model = _moradiaAppService.ObterPorId(id);
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

        // POST: Moradia/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MoradiaViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _moradiaAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _moradiaAppService.Remover(model);

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
        public ActionResult Morador(int id)
        {
            try
            {
                return View(new MoradorViewModel { MoradiaId = id });
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Details", new { id = id });
        }

        [HttpPost]
        public ActionResult Morador(MoradorViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);                

                // TODO: Add insert logic here
                _moradorAppService.Incluir(model);

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

            return RedirectToAction("Details", new { id = model.MoradiaId });
        }

        // POST: Sindico/Pessoa
        [HttpPost]
        public ActionResult Pessoa(MoradorViewModel model)
        {
            try
            {
                if (model.PessoaId > 0)
                {
                    model.Pessoa = _pessoaFisicaAppService.ObterPorId(model.PessoaId);
                    if (model.Pessoa == null)
                        throw new KeyNotFoundException();
                }
                else if (!string.IsNullOrEmpty(model.Pessoa.Nome))
                {
                    //Obter os PessoaId que já estão como Sindicos para o condominio atual para não trazer na pesquisa de novo
                    IEnumerable<int> SaoMoradores = _moradorAppService.Todos().Select(s => s.PessoaId).ToList();

                    ViewBag.PessoaSet = _pessoaFisicaAppService.Filtrar(f => !SaoMoradores.Contains(f.Id) && f.Nome.ToLower().Contains(model.Pessoa.Nome.ToLower()));
                }

                return View("Morador", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Details", new { id = model.MoradiaId });
        }

    }
}
