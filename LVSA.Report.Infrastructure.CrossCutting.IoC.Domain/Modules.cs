using LVSA.Report.Domain.Interfaces.Repository;
using LVSA.Report.Domain.Interfaces.Services;
using LVSA.Report.Domain.Services;
using LVSA.Report.Infrastructure.Data.Repository.EF;
using Ninject.Modules;

namespace LVSA.Report.Infrastructure.CrossCutting.IoC.Domain
{
    public class Modules : NinjectModule
    {
        public override void Load()
        {
            //Aplicacao
            Bind<IConsultaRepository>().To<ConsultaRepository>();
            Bind<IConsultaService>().To<ConsultaService>();
            //Parametro
            Bind<IParametroRepository>().To<ParametroRepository>();
            Bind<IParametroService>().To<ParametroService>();
            //ReadOnly
            //Bind<IReadOnlyRepository>().To<ReadOnlyRepository>();
            //Bind<IReadOnlyService>().To<ReadOnlyService>();
            //ConsultaParametro
            Bind<IConsultaParametroRepository>().To<ConsultaParametroRepository>();
            Bind<IConsultaParametroService>().To<ConsultaParametroService>();
            //Instrucao
            Bind<IInstrucaoRepository>().To<InstrucaoRepository>();
            Bind<IInstrucaoService>().To<InstrucaoService>();
            //Cubo
            Bind<ICuboRepository>().To<CuboRepository>();
            Bind<ICuboService>().To<CuboService>();
            //CategoriaCubo
            Bind<ICategoriaCuboRepository>().To<CategoriaCuboRepository>();
            Bind<ICategoriaCuboService>().To<CategoriaCuboService>();
            //CategoriaInstrucao
            Bind<ICategoriaInstrucaoRepository>().To<CategoriaInstrucaoRepository>();
            Bind<ICategoriaInstrucaoService>().To<CategoriaInstrucaoService>();
            //CategoriaConsulta
            Bind<ICategoriaConsultaRepository>().To<CategoriaConsultaRepository>();
            Bind<ICategoriaConsultaService>().To<CategoriaConsultaService>();
            //Grupo
            Bind<IGrupoRepository>().To<GrupoRepository>();
            Bind<IGrupoService>().To<GrupoService>();
            //GrupoAcessoCubo
            Bind<IGrupoAcessoCuboRepository>().To<GrupoAcessoCuboRepository>();
            Bind<IGrupoAcessoCuboService>().To<GrupoAcessoCuboService>();
            //UsuarioGrupo
            Bind<IUsuarioGrupoRepository>().To<UsuarioGrupoRepository>();
            Bind<IUsuarioGrupoService>().To<UsuarioGrupoService>();
        }
    }
}
