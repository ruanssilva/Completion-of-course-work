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
    public class ConexaoController : ControllerBase
    {
        private readonly IConexaoAppService _conexaoAppService;

        public ConexaoController(IConexaoAppService conexaoAppService)
        {
            _conexaoAppService = conexaoAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _conexaoAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: Conexao
        public ActionResult Index()
        {
            try
            {
                var conexaoset = _conexaoAppService.Todos();

                return View("Index", conexaoset);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Conexao/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var conexao = _conexaoAppService.ObterPorId(id);

                if (conexao == null)
                    throw new NoRecordsFoundException("Conexão não encontrada");

                return View("Details", conexao);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: Conexao/Create
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

        // POST: Conexao/Create
        [HttpPost]
        public ActionResult Create(ConexaoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                _conexaoAppService.Incluir(model);

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

        // GET: Conexao/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var conexao = _conexaoAppService.ObterPorId(id);

                if (conexao == null)
                    throw new NoRecordsFoundException("Conexão não encontrada");

                return View("Edit", conexao);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Conexao/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ConexaoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                _conexaoAppService.Atualizar(model);

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

        // GET: Conexao/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var conexao = _conexaoAppService.ObterPorId(id);

                if (conexao == null)
                    throw new NoRecordsFoundException("Conexão não encontrada");

                return View("Delete", conexao);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Conexao/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ConexaoViewModel model)
        {
            try
            {
                var conexao = _conexaoAppService.ObterPorId(id);
                if (conexao != null)
                {
                    _conexaoAppService.Remover(model);

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
