

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
    public class MultarController : SindicoControllerBase
    {
        private readonly IMultaMoradorAppService _multaMoradorAppService;
        private readonly IMoradorAppService _moradorAppService;
        private readonly ILancamentoAppService _lancamentoAppService;
        private readonly ICCustoAppService _cCustoAppService;
        private readonly IPessoaFisicaComplementoAppService _pessoaFisicaComplementoAppService;
        private readonly IMultaAppService _multaAppService;

        public MultarController(IMultaMoradorAppService multaMoradorAppService, IMultaAppService multaAppService, IMoradorAppService moradorAppService, ILancamentoAppService lancamentoAppService, ICCustoAppService cCustoAppService, IPessoaFisicaComplementoAppService pessoaFisicaComplementoAppService)
        {
            _multaMoradorAppService = multaMoradorAppService;
            _moradorAppService = moradorAppService;
            _lancamentoAppService = lancamentoAppService;
            _cCustoAppService = cCustoAppService;
            _pessoaFisicaComplementoAppService = pessoaFisicaComplementoAppService;
            _multaAppService = multaAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Contexto.IsAuthentication())
            {
                _multaMoradorAppService.SetSeguranca(Contexto.Seguranca);
                _moradorAppService.SetSeguranca(Contexto.Seguranca);
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
                //Notifications.Add(new NotificationViewModel
                //{
                //    Title = "Você não é um sindico.",
                //    Message = "Essa área no sistema é exclusiva para sindicos, procure o administrador para mais informações.",
                //    TimeOut = 800,
                //    Center = true,
                //    Position = Position.TopRight,
                //    Status = Status.Info,
                //    Icon = Icon.Info,
                //});

                filterContext.Result = RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.MoradorSet = _moradorAppService.Filtrar(f => f.Ativo && f.Moradia.Ativo && f.Moradia.Bloco.Ativo && f.Moradia.Bloco.SindicoId == Sindico.Id);
            }
        }

        // GET: Multar
        public ActionResult Index()
        {
            try
            {
                

                return View(new MultaMoradorAppViewModel());
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST: Multar
        [HttpPost]
        public ActionResult Index(MultaMoradorAppViewModel model)
        {
            try
            {
                model.MoradorIdSet = model.MoradorIdSet ?? new int[] { };

                model.MultaMoradorSet = _multaMoradorAppService.Filtrar(f =>
                    (f.Morador.Moradia.Ativo) &&
                    (f.Morador.Moradia.Bloco.Ativo) &&
                    (f.Morador.Moradia.Bloco.SindicoId == Sindico.Id) &&
                    (model.MoradorIdSet.Count() > 0 ? model.MoradorIdSet.Contains(f.MoradorId) : true) &&
                    (model.DataFiltroInicio != null ? f.DataReferencia >= model.DataFiltroInicio : true) &&
                    (model.DataFiltroFinal != null ? f.DataReferencia <= model.DataFiltroFinal : true) &&
                    (model.FiltroPago != null ? (model.FiltroPago == true ? (f.DataPagamento != null) : (f.DataPagamento == null)) : true)
                );

                ViewBag.MoradorSet = _moradorAppService.Filtrar(f => f.Ativo && f.Moradia.Bloco.SindicoId == Sindico.Id);

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Multar/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                MultaMoradorViewModel model = _multaMoradorAppService.ObterPorId(id);
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

        // GET: Multar/Create
        public ActionResult Create()
        {
            try
            {
                
                ViewBag.MultaSet = _multaAppService.Filtrar(f => f.Ativo);

                return View(new MultaMoradorAppViewModel { DataReferencia = DateTime.Now });
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Multar/Create
        [HttpPost]
        public ActionResult Create(MultaMoradorAppViewModel model)
        {
            try
            {
                ModelState.Remove("DataPagamento");

                if (!ModelState.IsValid)
                {
                    ViewBag.MultaSet = _multaAppService.Filtrar(f => f.Ativo);

                    return View(model);
                }

                List<int> MoradorIds = _moradorAppService.Filtrar(f => f.Ativo && f.Moradia.Bloco.SindicoId == Sindico.Id).Select(s => s.Id).ToList();

                MultaViewModel multa = _multaAppService.ObterPorId(model.MultaId);
                if (multa == null)
                    throw new ArgumentNullException("multa");

                // TODO: Add insert logic here
                foreach (var cm in model.MoradorIdSet.Where(w => MoradorIds.Contains(w)))
                {
                    model.MoradorId = cm;
                    model.Valor = multa.Valor;
                    _multaMoradorAppService.Incluir(model);
                }

                List<int> PessoaIds = Sindico.Blocos.SelectMany(s => s.Moradias.SelectMany(sm => sm.Moradores)).Where(w => MoradorIds.Contains(w.Id)).Select(s => s.PessoaId).ToList();
                List<int> UsuarioIds = _pessoaFisicaComplementoAppService.Filtrar(f => PessoaIds.Contains(f.PessoaId) && f.UsuarioId != null).Select(s => (int)s.UsuarioId).ToList();

                foreach (int u in UsuarioIds)
                {
                    //_alertaAppService.Incluir(new AlertaViewModel
                    //{
                    //    Mensagem = HousingMessages.NovaMulta,
                    //    Icon = Icons.Exclamation,
                    //    Url = Url.Action("Index", "MinhaMulta"),
                    //    UsuarioId = u,
                    //    AplicacaoId = Seguranca.AplicacaoId
                    //});
                }

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

        // GET: Multar/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                MultaMoradorViewModel model = _multaMoradorAppService.Filtrar(f => f.Id == id && f.Morador.Moradia.Bloco.SindicoId == Sindico.Id).SingleOrDefault();
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

        // POST: Multar/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MultaMoradorViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _multaMoradorAppService.Filtrar(f => f.Id == id && f.Morador.Moradia.Bloco.SindicoId == Sindico.Id).SingleOrDefault();
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _multaMoradorAppService.Remover(model);

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


        // GET: Multar/Baixa/5
        public ActionResult Baixa(int id)
        {
            try
            {
                MultaMoradorAppViewModel model = new MultaMoradorAppViewModel(_multaMoradorAppService.Filtrar(f => f.Id == id && f.DataPagamento == null && f.Morador.Moradia.Bloco.SindicoId == Sindico.Id).SingleOrDefault());
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

        // POST: Multar/Baixa/5
        [HttpPost]
        public ActionResult Baixa(int id, MultaMoradorAppViewModel model)
        {
            try
            {
                foreach (var key in ModelState.Keys.ToList().Where(k => !k.Contains("DataPagamento") && !k.Contains("CCustoId")))
                    ModelState[key].Errors.Clear();

                if (!ModelState.IsValid)
                {
                    ViewBag.CCustoSet = _cCustoAppService.Filtrar(f => f.Ativo);

                    model = new MultaMoradorAppViewModel(_multaMoradorAppService.Filtrar(f => f.Id == id && f.DataPagamento == null && f.Morador.Moradia.Bloco.SindicoId == Sindico.Id).SingleOrDefault());

                    return View(model);
                }

                DateTime DataPagamento = model.DataPagamento.GetValueOrDefault();
                int CCustoId = model.CCustoId;
                decimal Juros = model.Juros;

                model = new MultaMoradorAppViewModel(_multaMoradorAppService.Filtrar(f => f.Id == id && f.DataPagamento == null && f.Morador.Moradia.Bloco.SindicoId == Sindico.Id).SingleOrDefault());

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

                _multaMoradorAppService.Atualizar(model);


                List<int> PessoaIds = model.Morador.Moradia.Moradores.Where(s => s.ResponsavelFinanceiro).Select(s => s.PessoaId).ToList();
                List<int> UsuarioIds = _pessoaFisicaComplementoAppService.Filtrar(f => PessoaIds.Contains(f.PessoaId) && f.UsuarioId != null).Select(s => (int)s.UsuarioId).ToList();

                foreach (int u in UsuarioIds)
                {
                    //_alertaAppService.Incluir(new AlertaViewModel
                    //{
                    //    Mensagem = HousingMessages.NovaBaixaMulta,
                    //    Icon = Icons.Baixa,
                    //    Url = Url.Action("Index", "MinhaMulta"),
                    //    UsuarioId = u,
                    //    AplicacaoId = Seguranca.AplicacaoId
                    //});
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
