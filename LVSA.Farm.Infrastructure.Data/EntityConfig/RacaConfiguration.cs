using LVSA.Farm.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Infrastructure.Data.EntityConfig
{
    public class RacaConfiguration : EntityTypeConfiguration<Raca>
    {
        public RacaConfiguration()
        {
            ToTable("Raca", "Farm");

            HasRequired(r => r.TipoAnimal)
                .WithMany(wm => wm.RacaSet)
                .HasForeignKey(fk => fk.TipoAnimalId);

            HasMany(hm => hm.RetratoSet)
                .WithOptional()
                .HasForeignKey(fk => fk.RacaId);
        }
    }
}
