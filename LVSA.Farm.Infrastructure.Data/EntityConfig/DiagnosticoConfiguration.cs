using LVSA.Farm.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Infrastructure.Data.EntityConfig
{
    public class DiagnosticoConfiguration : EntityTypeConfiguration<Diagnostico>
    {
        public DiagnosticoConfiguration()
        {
            ToTable("Diagnostico", "Farm");

            Property(p => p.Observacao)
                .HasMaxLength(255);

            HasRequired(hr => hr.Animal)
                .WithMany(wm => wm.DiagnosticoSet)
                .HasForeignKey(fk => fk.AnimalId);

            HasRequired(hr => hr.Doenca)
                .WithMany()
                .HasForeignKey(fk => fk.DoencaId);

            HasMany(hm => hm.RetratoSet)
                .WithOptional()
                .HasForeignKey(fk => fk.DiagnosticoId);
        }
    }
}
