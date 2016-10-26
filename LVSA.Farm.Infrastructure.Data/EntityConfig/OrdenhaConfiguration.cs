using LVSA.Farm.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Infrastructure.Data.EntityConfig
{
    public class OrdenhaConfiguration : EntityTypeConfiguration<Ordenha>
    {
        public OrdenhaConfiguration()
        {
            ToTable("Ordenha", "Farm");

            HasRequired(hr => hr.Animal)
                .WithMany()
                .HasForeignKey(fk => fk.AnimalId);
        }
    }
}
