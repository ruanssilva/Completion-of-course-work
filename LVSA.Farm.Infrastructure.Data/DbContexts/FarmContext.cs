using LVSA.Base.Infrastructure.Data.DbContexts;
using LVSA.Farm.Infrastructure.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Infrastructure.Data.DbContexts
{
    public class FarmContext : BaseContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new PastoConfiguration());
            modelBuilder.Configurations.Add(new PiqueteConfiguration());
            modelBuilder.Configurations.Add(new RetratoConfiguration());
            modelBuilder.Configurations.Add(new TerrenoConfiguration());
            modelBuilder.Configurations.Add(new TipoAnimalConfiguration());
            modelBuilder.Configurations.Add(new TipoMedicamentoConfiguration());
            modelBuilder.Configurations.Add(new MedicamentoConfiguration());
            modelBuilder.Configurations.Add(new AnimalConfiguration());
            modelBuilder.Configurations.Add(new DoencaConfiguration());
            modelBuilder.Configurations.Add(new MedicacaoConfiguration());
            modelBuilder.Configurations.Add(new RacaConfiguration());
            modelBuilder.Configurations.Add(new LocalPesagemConfiguration());
            modelBuilder.Configurations.Add(new TratamentoConfiguration());
            modelBuilder.Configurations.Add(new DosagemConfiguration());
            modelBuilder.Configurations.Add(new DiagnosticoConfiguration());
            modelBuilder.Configurations.Add(new PrescricaoConfiguration());
            modelBuilder.Configurations.Add(new OrdenhaConfiguration());

        }
    }
}
