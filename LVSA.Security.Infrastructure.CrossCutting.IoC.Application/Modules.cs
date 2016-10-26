using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Application;
using LVSA.Security.Application.Interfaces;

namespace LVSA.Security.Infrastructure.CrossCutting.IoC.Application
{
    public class Modules : NinjectModule
    {
        public override void Load()
        {   
            Bind<IAplicacaoAppService>().To<AplicacaoAppService>();
            Bind<IRecursoAppService>().To<RecursoAppService>();
            Bind<IGrupoAppService>().To<GrupoAppService>();
            Bind<IUsuarioAppService>().To<UsuarioAppService>();
            Bind<IContextoAppService>().To<ContextoAppService>();
            Bind<ITipoRecursoAppService>().To<TipoRecursoAppService>();
            Bind<ITipoUsuarioAppService>().To<TipoUsuarioAppService>();
            Bind<IParametroAppService>().To<ParametroAppService>();
            Bind<IConexaoAppService>().To<ConexaoAppService>();
            Bind<IColigadaAppService>().To<ColigadaAppService>();
            Bind<IFilialAppService>().To<FilialAppService>();
        }
    }
}
