using LVSA.Base.Infrastructure.Data.DbContexts;
using LVSA.Report.Infrastructure.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Infrastructure.Data.DbContexts
{


    public class ReportContext : BaseContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new ConsultaConfiguration());
            modelBuilder.Configurations.Add(new InstrucaoConfiguration());
            modelBuilder.Configurations.Add(new CuboConfiguration());
            modelBuilder.Configurations.Add(new ParametroConfiguration());
            modelBuilder.Configurations.Add(new ConsultaParametroConfiguration());
            modelBuilder.Configurations.Add(new CuboParametroConfiguration());
            modelBuilder.Configurations.Add(new CategoriaConsultaConfiguration());
            modelBuilder.Configurations.Add(new CategoriaCuboConfiguration());
            modelBuilder.Configurations.Add(new CategoriaInstrucaoConfiguration());
            modelBuilder.Configurations.Add(new GrupoConfiguration());
            modelBuilder.Configurations.Add(new GrupoAcessoCuboConfiguration());
            modelBuilder.Configurations.Add(new UsuarioGrupoConfiguration());

        }

    }
}
