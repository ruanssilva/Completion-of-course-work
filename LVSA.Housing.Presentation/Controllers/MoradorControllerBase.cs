using LVSA.Global.Application.Interfaces;
using LVSA.Housing.Application.Interfaces;
using LVSA.Housing.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using LVSA.Global.Application.ViewModels;

namespace LVSA.Housing.Presentation.Controllers
{
    public class MoradorControllerBase : ControllerBase
    {
        private readonly IPessoaFisicaAppService _pessoaFisicaAppService;
        private readonly IPessoaFisicaComplementoAppService _pessoaFisicaComplementoAppService;
        private readonly IMoradorAppService _moradorAppService;
        private readonly ISindicoAppService _sindicoAppService;
        private readonly IImagemAppService _imagemAppService;

        public MoradorControllerBase()
        {
            _pessoaFisicaAppService = LVSA.Base.Presentation.App_Start.NinjectWebCommon.Kernel.Get<IPessoaFisicaAppService>();
            _pessoaFisicaComplementoAppService = LVSA.Base.Presentation.App_Start.NinjectWebCommon.Kernel.Get<IPessoaFisicaComplementoAppService>();
            _moradorAppService = LVSA.Base.Presentation.App_Start.NinjectWebCommon.Kernel.Get<IMoradorAppService>();
            _sindicoAppService = LVSA.Base.Presentation.App_Start.NinjectWebCommon.Kernel.Get<ISindicoAppService>();
            _imagemAppService = LVSA.Base.Presentation.App_Start.NinjectWebCommon.Kernel.Get<IImagemAppService>();
        }

        protected MoradorViewModel Morador
        {
            get
            {
                return _morador;
            }
            set
            {
                _morador = value;
            }
        }

        private MoradorViewModel _morador
        {
            get
            {
                return GetCache<MoradorViewModel>("Morador#" + Token);
            }
            set
            {
                SetCache<MoradorViewModel>(value, "Morador#" + Token);
            }
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Morador == null)
            {
                var complemento = _pessoaFisicaComplementoAppService.Filtrar(f => f.UsuarioId == Contexto.Seguranca.Usuario.Id).SingleOrDefault();
                if (complemento != null)
                {
                    Morador = _moradorAppService.Filtrar(f => f.PessoaId == complemento.PessoaId).SingleOrDefault();

                    PessoaFisicaViewModel pessoa = _pessoaFisicaAppService.ObterPorId(complemento.PessoaId);

                    if (Morador != null)
                        Morador.Pessoa = pessoa;
                }
            }
        }

    }
}