using LVSA.Farm.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Infrastructure.Data.EntityConfig
{
    public class TerrenoConfiguration : EntityTypeConfiguration<Terreno>
    {
        public TerrenoConfiguration()
        {
            ToTable("Terreno", "Farm");

            HasKey(hk => new { hk.ColigadaId, hk.FilialId });

            HasMany(hm => hm.PastoSet)
                .WithRequired()
                .HasForeignKey(fk => new { fk.ColigadaId, fk.FilialId });
        }
    }
}
