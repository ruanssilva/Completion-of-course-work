using LVSA.Global.Domain.Interfaces.Repository;
using LVSA.Global.Domain.Interfaces.Services;
using LVSA.Global.Domain.Services;
using LVSA.Global.Infrastructure.Data.Repository.EF;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Global.Infrastructure.CrossCutting.IoC.Domain
{
    public class Modules : NinjectModule
    {
        public override void Load()
        {
            //Bairro
            Bind<IBairroRepository>().To<BairroRepository>();
            Bind<IBairroService>().To<BairroService>();
            //Cidade
            Bind<ICidadeRepository>().To<CidadeRepository>();
            Bind<ICidadeService>().To<CidadeService>();
            //ColigadaComplemento
            Bind<IColigadaComplementoRepository>().To<ColigadaComplementoRepository>();
            Bind<IColigadaComplementoService>().To<ColigadaComplementoService>();
            //Escolaridade
            Bind<IEscolaridadeRepository>().To<EscolaridadeRepository>();
            Bind<IEscolaridadeService>().To<EscolaridadeService>();
            //Estado
            Bind<IEstadoRepository>().To<EstadoRepository>();
            Bind<IEstadoService>().To<EstadoService>();
            //FilialComplemento
            Bind<IFilialComplementoRepository>().To<FilialComplementoRepository>();
            Bind<IFilialComplementoService>().To<FilialComplementoService>();
            //Imagem
            Bind<IImagemRepository>().To<ImagemRepository>();
            Bind<IImagemService>().To<ImagemService>();
            //PessoaFisica
            Bind<IPessoaFisicaRepository>().To<PessoaFisicaRepository>();
            Bind<IPessoaFisicaService>().To<PessoaFisicaService>();
            //PessoaFisicaComplemento
            Bind<IPessoaFisicaComplementoRepository>().To<PessoaFisicaComplementoRepository>();
            Bind<IPessoaFisicaComplementoService>().To<PessoaFisicaComplementoService>();
            //PessoaJuridica
            Bind<IPessoaJuridicaRepository>().To<PessoaJuridicaRepository>();
            Bind<IPessoaJuridicaService>().To<PessoaJuridicaService>();
            //RacaCor
            Bind<IRacaCorRepository>().To<RacaCorRepository>();
            Bind<IRacaCorService>().To<RacaCorService>();
            //Titulacao
            Bind<ITitulacaoRepository>().To<TitulacaoRepository>();
            Bind<ITitulacaoService>().To<TitulacaoService>();
            //Pais
            Bind<IPaisRepository>().To<PaisRepository>();
            Bind<IPaisService>().To<PaisService>();

        }
    }
}
