

using LVSA.Base.Presentation.ViewModels;
using LVSA.Financial.Application.Interfaces;
using LVSA.Financial.Application.ViewModels;
using LVSA.Global.Application.Interfaces;
using LVSA.Housing.Application.Interfaces;
using LVSA.Housing.Application.ViewModels;
using LVSA.Housing.Presentation.ViewModels;
using LVSA.Security.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Housing.Presentation.Controllers
{
    public class CustoController : SindicoControllerBase
    {
        private readonly ICustoMoradiaAppService _custoMoradiaAppService;
        private readonly IMoradiaAppService _moradiaAppService;
        private readonly ILancamentoAppService _lancamentoAppService;
        private readonly ICCustoAppService _cCustoAppService;
        private readonly IPessoaFisicaComplementoAppService _pessoaFisicaComplementoAppService;

        public CustoController(ICustoMoradiaAppService custoMoradiaAppService, IPessoaFisicaComplementoAppService pessoaFisicaComplementoAppService, IMoradiaAppService moradiaAppService, ILancamentoAppService lancamentoAppService, ICCustoAppService cCustoAppService)
        {
            _custoMoradiaAppService = custoMoradiaAppService;
            _moradiaAppService = moradiaAppService;
            _lancamentoAppService = lancamentoAppService;
            _cCustoAppService = cCustoAppService;
            _pessoaFisicaComplementoAppService = pessoaFisicaComplementoAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Contexto.IsAuthentication())
            {
                _custoMoradiaAppService.SetSeguranca(Contexto.Seguranca);
                _moradiaAppService.SetSeguranca(Contexto.Seguranca);
                _lancamentoAppService.SetSeguranca(Contexto.Seguranca);
                _cCustoAppService.SetSeguranca(Contexto.Seguranca);
                _pessoaFisicaComplementoAppService.SetSeguranca(Contexto.Seguranca);
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (Sindico == null)
            {
                Gritters.Add(new GritterViewModel
                {
                    Tittle = "Você não é um sindico.",
                    Message = "Essa área no sistema é exclusiva para sindicos, procure o administrador para mais informações.",
                    Center = true,
                    Sticky = true,
                    Style = GritterStyle.Information,
                });

                filterContext.Result = RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.MoradiaSet = _moradiaAppService.Filtrar(f => f.Ativo && f.Bloco.Ativo && f.Bloco.SindicoId == Sindico.Id);
            }

        }

        // GET: CustoMoradia
        public ActionResult Index()
        {
            try
            {

                return View(new CustoMoradiaAppViewModel());
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST: Moradia/Index
        [HttpPost]
        public ActionResult Index(CustoMoradiaAppViewModel model)
        {
            try
            {
                model.MoradiaIdSet = model.MoradiaIdSet ?? new int[] { };

                model.CustoMoradiaSet = _custoMoradiaAppService.Filtrar(f =>
                    (f.Moradia.Bloco.Ativo) &&
                    (f.Moradia.Ativo) &&
                    (f.Moradia.Bloco.SindicoId == Sindico.Id) &&
                    (model.MoradiaIdSet.Count() > 0 ? model.MoradiaIdSet.Contains(f.MoradiaId) : true) &&
                    (model.DataFiltroInicio != null ? f.DataReferencia >= model.DataFiltroInicio : true) &&
                    (model.DataFiltroFinal != null ? f.DataReferencia <= model.DataFiltroFinal : true) &&
                    (model.FiltroPago != null ? (model.FiltroPago == true ? (f.DataPagamento != null) : (f.DataPagamento == null)) : true)
                );

                ViewBag.MoradiaSet = _moradiaAppService.Filtrar(f => f.Ativo && f.Bloco.SindicoId == Sindico.Id);

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: CustoMoradia/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                CustoMoradiaViewModel model = _custoMoradiaAppService.ObterPorId(id);
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

        // GET: CustoMoradia/Create
        public ActionResult Create()
        {
            try
            {

                return View(new CustoMoradiaAppViewModel { DataReferencia = DateTime.Now });
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: CustoMoradia/Create
        [HttpPost]
        public ActionResult Create(CustoMoradiaAppViewModel model)
        {
            try
            {
                ModelState.Remove("DataPagamento");

                if (!ModelState.IsValid)
                    return View(model);

                List<int> MoradiaIds = _moradiaAppService.Filtrar(f => f.Ativo && f.Bloco.SindicoId == Sindico.Id).Select(s => s.Id).ToList();

                if (model.Rateado)
                    model.Valor = model.Valor / MoradiaIds.Count();

                foreach (var cm in model.MoradiaIdSet.Where(w => MoradiaIds.Contains(w)))
                {
                    model.MoradiaId = cm;
                    _custoMoradiaAppService.Incluir(model);
                }

                List<int> PessoaIds = Sindico.Blocos.SelectMany(s => s.Moradias.SelectMany(sm => sm.Moradores)).Where(w => MoradiaIds.Contains(w.MoradiaId) && w.ResponsavelFinanceiro).Select(s => s.PessoaId).ToList();
                List<int> UsuarioIds = _pessoaFisicaComplementoAppService.Filtrar(f => PessoaIds.Contains(f.PessoaId) && f.UsuarioId != null).Select(s => (int)s.UsuarioId).ToList();

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

        // GET: CustoMoradia/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                CustoMoradiaViewModel model = _custoMoradiaAppService.Filtrar(f => f.Id == id && f.Moradia.Bloco.SindicoId == Sindico.Id).SingleOrDefault();
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

        // POST: CustoMoradia/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CustoMoradiaViewModel model)
        {
            try
            {
                model = _custoMoradiaAppService.Filtrar(f => f.Id == id && f.Moradia.Bloco.SindicoId == Sindico.Id).SingleOrDefault();
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _custoMoradiaAppService.Remover(model);

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

        // GET: CustoMoradia/Baixa/5
        public ActionResult Baixa(int id)
        {
            try
            {
                CustoMoradiaAppViewModel model = new CustoMoradiaAppViewModel(_custoMoradiaAppService.Filtrar(f => f.Id == id && f.DataPagamento == null && f.Moradia.Bloco.SindicoId == Sindico.Id).SingleOrDefault());
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                ViewBag.CCustoSet = _cCustoAppService.Filtrar(f => f.Ativo);

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: CustoMoradia/Baixa/5
        [HttpPost]
        public ActionResult Baixa(int id, CustoMoradiaAppViewModel model)
        {
            try
            {

                foreach (var key in ModelState.Keys.ToList().Where(k => !k.Contains("DataPagamento") && !k.Contains("CCustoId")))
                    ModelState[key].Errors.Clear();

                if (!ModelState.IsValid)
                {
                    ViewBag.CCustoSet = _cCustoAppService.Filtrar(f => f.Ativo);

                    model = new CustoMoradiaAppViewModel(_custoMoradiaAppService.Filtrar(f => f.Id == id && f.DataPagamento == null && f.Moradia.Bloco.SindicoId == Sindico.Id).SingleOrDefault());

                    return View(model);
                }

                DateTime DataPagamento = model.DataPagamento.GetValueOrDefault();
                int CCustoId = model.CCustoId;
                decimal Juros = model.Juros;

                model = new CustoMoradiaAppViewModel(_custoMoradiaAppService.Filtrar(f => f.Id == id && f.DataPagamento == null && f.Moradia.Bloco.SindicoId == Sindico.Id).SingleOrDefault());

                if (model == null)
                    throw new Exception("Registro não encontrado.");

                model.DataPagamento = DataPagamento;
                model.CCustoId = CCustoId;
                model.Juros = Juros;

                _lancamentoAppService.Incluir(new LancamentoViewModel
                {
                    CCustoId = model.CCustoId,
                    Descricao = model.Descricao,
                    Valor = model.Valor - model.Desconto + model.Juros
                });

                _custoMoradiaAppService.Atualizar(model);


                List<int> PessoaIds = model.Moradia.Moradores.Where(s => s.ResponsavelFinanceiro).Select(s => s.PessoaId).ToList();
                List<int> UsuarioIds = _pessoaFisicaComplementoAppService.Filtrar(f => PessoaIds.Contains(f.PessoaId) && f.UsuarioId != null).Select(s => (int)s.UsuarioId).ToList();

            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }
    }
}
