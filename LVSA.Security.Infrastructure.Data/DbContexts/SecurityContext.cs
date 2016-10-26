using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Infrastructure.Data.DbContexts;
using LVSA.Base.Infrastructure.Data.Interfaces;
using LVSA.Security.Infrastructure.Data.EntityConfig;

namespace LVSA.Security.Infrastructure.Data.DbContexts
{
    public class SecurityContext : BaseContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AgrupamentoConfiguration());
            modelBuilder.Configurations.Add(new AplicacaoAcessoConfiguration());
            modelBuilder.Configurations.Add(new AplicacaoConfiguration());
            modelBuilder.Configurations.Add(new AplicacaoDependenciaConfiguration());
            modelBuilder.Configurations.Add(new GrupoConfiguration());
            modelBuilder.Configurations.Add(new ParametrizacaoConfiguration());
            modelBuilder.Configurations.Add(new ParametroConfiguration());
            modelBuilder.Configurations.Add(new PerfilContextoConfiguration());
            modelBuilder.Configurations.Add(new PermissaoConfiguration());
            modelBuilder.Configurations.Add(new RecursoConfiguration());
            modelBuilder.Configurations.Add(new TipoRecursoConfiguration());
            modelBuilder.Configurations.Add(new TipoUsuarioConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new NotificacaoConfiguration());
            modelBuilder.Configurations.Add(new NotificacaoVisualizadaConfiguration());
            modelBuilder.Configurations.Add(new ConexaoConfiguration());
            modelBuilder.Configurations.Add(new ColigadaConfiguration());
            modelBuilder.Configurations.Add(new FilialConfiguration());
            modelBuilder.Configurations.Add(new UsuarioFilialConfiguration());
        }
    }
}
