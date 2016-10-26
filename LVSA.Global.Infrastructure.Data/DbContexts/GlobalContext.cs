using LVSA.Base.Infrastructure.Data.DbContexts;
using LVSA.Global.Infrastructure.Data.EntityConfig;
using LVSA.Global.Infrastructure.Data.Interfaces;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace LVSA.Global.Infrastructure.Data.DbContexts
{
    public class GlobalContext : BaseContext
    {
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Configurations.Add(new PessoaFisicaConfiguration());
            modelBuilder.Configurations.Add(new PessoaFisicaComplementoConfiguration());
            modelBuilder.Configurations.Add(new PessoaJuridicaConfiguration());
            modelBuilder.Configurations.Add(new BairroConfiguration());
            modelBuilder.Configurations.Add(new CidadeConfiguration());
            modelBuilder.Configurations.Add(new EstadoConfiguration());
            modelBuilder.Configurations.Add(new TitulacaoConfiguration());
            modelBuilder.Configurations.Add(new EscolaridadeConfiguration());
            modelBuilder.Configurations.Add(new RacaCorConfiguration());
            modelBuilder.Configurations.Add(new PaisConfiguration());
            modelBuilder.Configurations.Add(new ImagemConfiguration());
        }

    }
}
