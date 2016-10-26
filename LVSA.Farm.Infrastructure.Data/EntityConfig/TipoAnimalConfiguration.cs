using LVSA.Farm.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Infrastructure.Data.EntityConfig
{
    public class TipoAnimalConfiguration : EntityTypeConfiguration<TipoAnimal>
    {
        public TipoAnimalConfiguration()
        {
            ToTable("TipoAnimal", "Farm");

            HasMany(hm => hm.RetratoSet)
                .WithOptional()
                .HasForeignKey(fk => fk.TipoAnimalId);
            
        }
    }
}
