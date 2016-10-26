using LVSA.Base.Presentation.ViewModels;
using LVSA.Global.Application.Interfaces;
using LVSA.Housing.Application.Interfaces;
using LVSA.Security.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LVSA.Housing.Presentation.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly IReuniaoAppService _reuniaoAppService;
        private readonly IPessoaFisicaAppService _pessoaFisicaAppService;
        private readonly IMoradorAppService _moradorAppService;
        private readonly ISindicoAppService _sindicoAppService;

        public HomeController(IReuniaoAppService reuniapAppService, IPessoaFisicaAppService pessoaFisicaAppService, IMoradorAppService moradorAppService, ISindicoAppService sindicoAppService)
        {
            _reuniaoAppService = reuniapAppService;
            _pessoaFisicaAppService = pessoaFisicaAppService;
            _moradorAppService = moradorAppService;
            _sindicoAppService = sindicoAppService;
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Contexto.IsAuthentication())
            {
                _reuniaoAppService.SetSeguranca(Contexto.Seguranca);
                _pessoaFisicaAppService.SetSeguranca(Contexto.Seguranca);
                _sindicoAppService.SetSeguranca(Contexto.Seguranca);
            }
        }

        // GET: Home
        public virtual ActionResult Index()
        {
            int pessoaid = _pessoaFisicaAppService.Filtrar(f => f.PessoaComplemento.UsuarioId == Contexto.Seguranca.Usuario.Id).Select(s => s.Id).SingleOrDefault();
            int moradorid = _moradorAppService.Filtrar(f => f.PessoaId == pessoaid).Select(s => s.Id).SingleOrDefault();
            int sindicoid = _sindicoAppService.Filtrar(f => f.PessoaId == pessoaid).Select(s => s.Id).SingleOrDefault();
            ViewBag.ReuniaoSet = _reuniaoAppService.Reunioes();

            ViewBag.PessoaId = pessoaid;
            ViewBag.MoradorId = moradorid;
            ViewBag.SindicoId = sindicoid;

            return View();
        }

        public ActionResult Dashboard()
        {
            try
            {

                ViewBag.ReuniaoSet = _reuniaoAppService.Reunioes();

                return View("Index");
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }
    }
}