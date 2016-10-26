using LVSA.Base.Infrastructure.Data.DbContexts;
using LVSA.Housing.Infrastructure.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Housing.Infrastructure.Data.DbContexts
{
    public class HousingContext : BaseContext
    {
        
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new BlocoConfiguration());
            modelBuilder.Configurations.Add(new MoradiaConfiguration());
            modelBuilder.Configurations.Add(new CondominioConfiguration());
            modelBuilder.Configurations.Add(new SindicoConfiguration());
            modelBuilder.Configurations.Add(new MoradorConfiguration());
            modelBuilder.Configurations.Add(new CustoMoradiaConfiguration());
            modelBuilder.Configurations.Add(new AvisoConfiguration());
            modelBuilder.Configurations.Add(new MultaConfiguration());
            modelBuilder.Configurations.Add(new MultaMoradorConfiguration());
            modelBuilder.Configurations.Add(new ReuniaoConfiguration());
            modelBuilder.Configurations.Add(new PresencaConfiguration());
        }

    }
}
