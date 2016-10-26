using LVSA.Report.Application;
using LVSA.Report.Application.Interfaces;
using Ninject.Modules;

namespace LVSA.Report.Infrastructure.CrossCutting.IoC.Application
{
    public class Modules : NinjectModule
    {
        public override void Load()
        {
            //Consulta
            Bind<IConsultaAppService>().To<ConsultaAppService>();
            //Parametro
            Bind<IParametroAppService>().To<ParametroAppService>();
            //Instrucao
            Bind<IInstrucaoAppService>().To<InstrucaoAppService>();
            //Cubo
            Bind<ICuboAppService>().To<CuboAppService>();
            //CategoriaCubo
            Bind<ICategoriaCuboAppService>().To<CategoriaCuboAppService>();
            //CategoriaConsulta
            Bind<ICategoriaConsultaAppService>().To<CategoriaConsultaAppService>();
            //CategoriaInstrucao
            Bind<ICategoriaInstrucaoAppService>().To<CategoriaInstrucaoAppService>();
            //Grupo
            Bind<IGrupoAppService>().To<GrupoAppService>();
            //UsuarioGrupo
            Bind<IUsuarioGrupoAppService>().To<UsuarioGrupoAppService>();
        }

    }
}
