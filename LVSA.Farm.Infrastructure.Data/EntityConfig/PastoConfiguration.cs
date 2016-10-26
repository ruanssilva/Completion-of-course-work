using LVSA.Farm.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Infrastructure.Data.EntityConfig
{
    public class PastoConfiguration : EntityTypeConfiguration<Pasto>
    {
        public PastoConfiguration()
        {
            ToTable("Pasto", "Farm");

            HasRequired(hr => hr.Terreno)
                .WithMany()
                .HasForeignKey(fk => new { fk.ColigadaId, fk.FilialId });

            HasMany(hm => hm.PiqueteSet)
                .WithRequired()
                .HasForeignKey(fk => fk.PastoId);

            HasMany(hm => hm.RetratoSet)
                .WithOptional()
                .HasForeignKey(fk => fk.PastoId);
                
        }
    }
}
