using LVSA.Global.Application.Interfaces;
using LVSA.Housing.Application.Interfaces;
using LVSA.Housing.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using System.Web;
using System.Web.Mvc;
using LVSA.Global.Application.ViewModels;

namespace LVSA.Housing.Presentation.Controllers
{
    public class SindicoControllerBase : ControllerBase
    {
        private readonly IPessoaFisicaAppService _pessoaFisicaAppService;
        private readonly IPessoaFisicaComplementoAppService _pessoaFisicaComplementoAppService;
        private readonly IMoradorAppService _moradorAppService;
        private readonly ISindicoAppService _sindicoAppService;
        private readonly IImagemAppService _imagemAppService;

        public SindicoControllerBase()
        {
            _pessoaFisicaAppService = LVSA.Base.Presentation.App_Start.NinjectWebCommon.Kernel.Get<IPessoaFisicaAppService>();
            _pessoaFisicaComplementoAppService = LVSA.Base.Presentation.App_Start.NinjectWebCommon.Kernel.Get<IPessoaFisicaComplementoAppService>();
            _moradorAppService = LVSA.Base.Presentation.App_Start.NinjectWebCommon.Kernel.Get<IMoradorAppService>();
            _sindicoAppService = LVSA.Base.Presentation.App_Start.NinjectWebCommon.Kernel.Get<ISindicoAppService>();
            _imagemAppService = LVSA.Base.Presentation.App_Start.NinjectWebCommon.Kernel.Get<IImagemAppService>();
        }

        protected SindicoViewModel Sindico
        {
            get
            {
                return _sindico;
            }
            set
            {
                _sindico = value;
            }
        }

        private SindicoViewModel _sindico
        {
            get
            {
                return GetCache<SindicoViewModel>("Sindico#" + Token);
            }
            set
            {
                SetCache<SindicoViewModel>(value, "Sindico#" + Token);
            }
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Sindico == null)
            {
                var complemento = _pessoaFisicaComplementoAppService.Filtrar(f => f.UsuarioId == Contexto.Seguranca.Usuario.Id).SingleOrDefault();
                if (complemento != null)
                {
                    Sindico = _sindicoAppService.Filtrar(f => f.PessoaId == complemento.PessoaId).SingleOrDefault();

                    PessoaFisicaViewModel pessoa = _pessoaFisicaAppService.ObterPorId(complemento.PessoaId);

                    if (Sindico != null)
                        Sindico.Pessoa = pessoa;
                }
            }
        }
    }
}