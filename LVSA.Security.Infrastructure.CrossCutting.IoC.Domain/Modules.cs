using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Domain.Interfaces.Repository;
using LVSA.Security.Domain.Interfaces.Services;
using LVSA.Security.Domain.Services;
using LVSA.Security.Infrastructure.Data.Repository.EF;

namespace LVSA.Security.Infrastructure.CrossCutting.IoC.Domain
{
    public class Modules : NinjectModule
    {
        public override void Load()
        {
            Bind<IAgrupamentoRepository>().To<AgrupamentoRepository>();
            Bind<IAgrupamentoService>().To<AgrupamentoService>();

            Bind<IAplicacaoAcessoRepository>().To<AplicacaoAcessoRepository>();
            Bind<IAplicacaoAcessoService>().To<AplicacaoAcessoService>();

            Bind<IAplicacaoDependenciaRepository>().To<AplicacaoDependenciaRepository>();
            Bind<IAplicacaoDependenciaService>().To<AplicacaoDependenciaService>();

            Bind<IAplicacaoRepository>().To<AplicacaoRepository>();
            Bind<IAplicacaoService>().To<AplicacaoService>();

            Bind<IGrupoRepository>().To<GrupoRepository>();
            Bind<IGrupoService>().To<GrupoService>();

            Bind<IParametroRepository>().To<ParametroRepository>();
            Bind<IParametroService>().To<ParametroService>();

            Bind<IPermissaoRepository>().To<PermissaoRepository>();
            Bind<IPermissaoService>().To<PermissaoService>();

            Bind<IRecursoRepository>().To<RecursoRepository>();
            Bind<IRecursoService>().To<RecursoService>();

            Bind<ITipoRecursoRepository>().To<TipoRecursoRepository>();
            Bind<ITipoRecursoService>().To<TipoRecursoService>();

            Bind<ITipoUsuarioRepository>().To<TipoUsuarioRepository>();
            Bind<ITipoUsuarioService>().To<TipoUsuarioService>();

            Bind<IUsuarioRepository>().To<UsuarioRepository>();
            Bind<IUsuarioService>().To<UsuarioService>();

            Bind<IParametrizacaoRepository>().To<ParametrizacaoRepository>();
            Bind<IParametrizacaoService>().To<ParametrizacaoService>();


            Bind<IUsuarioFilialRepository>().To<UsuarioFilialRepository>();
            Bind<IUsuarioFilialService>().To<UsuarioFilialService>();

            Bind<IColigadaRepository>().To<ColigadaRepository>();
            Bind<IColigadaService>().To<ColigadaService>();

            Bind<IFilialRepository>().To<FilialRepository>();
            Bind<IFilialService>().To<FilialService>();


            Bind<IConexaoRepository>().To<ConexaoRepository>();
            Bind<IConexaoService>().To<ConexaoService>();
        }
    }
}
