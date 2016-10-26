using LVSA.Global.Domain.Interfaces.Repository;
using LVSA.Global.Domain.Interfaces.Repository.ReadOnly;
using LVSA.Global.Domain.Interfaces.Services;
using LVSA.Global.Domain.Services;
using LVSA.Global.Infrastructure.Data.Repository.Dapper;
using LVSA.Global.Infrastructure.Data.Repository.EF;
using Ninject.Modules;

namespace LVSA.Global.Infrastructure.CrossCutting.IoC
{
    public class NinjectModules : NinjectModule
    {
        public override void Load()
        {
            //PessoaFisica
            Bind<IPessoaFisicaService>().To<PessoaFisicaService>();
            Bind<IPessoaFisicaRepository>().To<PessoaFisicaRepository>();
            Bind<IPessoaFisicaReadOnlyRepository>().To<PessoaFisicaReadOnlyRepository>();
            //PessoaFisicaComplemento
            Bind<IPessoaFisicaComplementoRepository>().To<PessoaFisicaComplementoRepository>();
            Bind<IPessoaFisicaComplementoService>().To<PessoaFisicaComplementoService>();
            //PessoaJuridica
            Bind<IPessoaJuridicaRepository>().To<PessoaJuridicaRepository>();
            Bind<IPessoaJuridicaService>().To<PessoaJuridicaService>();
            //Bairro
            Bind<IBairroRepository>().To<BairroRepository>();
            Bind<IBairroService>().To<BairroService>();
            //Estado
            Bind<IEstadoRepository>().To<EstadoRepository>();
            Bind<IEstadoService>().To<EstadoService>();
            //Cidade
            Bind<ICidadeRepository>().To<CidadeRepository>();
            Bind<ICidadeService>().To<CidadeService>();
            //ColigadaComplemento
            Bind<IColigadaComplementoRepository>().To<ColigadaComplementoRepository>();
            Bind<IColigadaComplementoService>().To<ColigadaComplementoService>();
            //FilialComplemento
            Bind<IFilialComplementoRepository>().To<FilialComplementoRepository>();
            Bind<IFilialComplementoService>().To<FilialComplementoService>();
            //RacaCor
            Bind<IRacaCorRepository>().To<RacaCorRepository>();
            Bind<IRacaCorService>().To<RacaCorService>();
            //Titulacao
            Bind<ITitulacaoRepository>().To<TitulacaoRepository>();
            Bind<ITitulacaoService>().To<TitulacaoService>();
            //Escolaridade
            Bind<IEscolaridadeRepository>().To<EscolaridadeRepository>();
            Bind<IEscolaridadeService>().To<EscolaridadeService>();
        }
    }
}
