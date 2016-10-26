using LVSA.Global.Application;
using LVSA.Global.Application.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Global.Infrastructure.CrossCutting.IoC.Application
{
    public class Modules : NinjectModule
    {
        public override void Load()
        {
            //Bairro
            Bind<IBairroAppService>().To<BairroAppService>();
            //Cidade
            Bind<ICidadeAppService>().To<CidadeAppService>();
            //ColigadaComplemento
            Bind<IColigadaComplementoAppService>().To<ColigadaComplementoAppService>();
            //Escolaridade
            Bind<IEscolaridadeAppService>().To<EscolaridadeAppService>();
            //Estado
            Bind<IEstadoAppService>().To<EstadoAppService>();
            //FilialComplemento
            Bind<IFilialComplementoAppService>().To<FilialComplementoAppService>();
            //Imagem
            Bind<IImagemAppService>().To<ImagemAppService>();
            //PessoaFisica
            Bind<IPessoaFisicaAppService>().To<PessoaFisicaAppService>();
            //PessoaFisicaComplemento
            Bind<IPessoaFisicaComplementoAppService>().To<PessoaFisicaComplementoAppService>();
            //PessoaJuridica
            Bind<IPessoaJuridicaAppService>().To<PessoaJuridicaAppService>();
            //RacaCor
            Bind<IRacaCorAppService>().To<RacaCorAppService>();
            //Titulacao
            Bind<ITitulacaoAppService>().To<TitulacaoAppService>();
            //Pais
            Bind<IPaisAppService>().To<PaisAppService>();
        }

    }
}
