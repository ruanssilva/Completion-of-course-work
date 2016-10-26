using LVSA.Farm.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Infrastructure.Data.EntityConfig
{
    public class PrescricaoConfiguration : EntityTypeConfiguration<Prescricao>
    {
        public PrescricaoConfiguration()
        {
            ToTable("Prescricao", "Farm");

            HasRequired(hr => hr.Tratamento)
                .WithMany()
                .HasForeignKey(fk => fk.TratamentoId);

            HasRequired(hr => hr.Animal)
                .WithMany()
                .HasForeignKey(fk => fk.AnimalId);

            HasOptional(ho => ho.Diagnostico)
                .WithMany(wm => wm.PrescricaoSet)
                .HasForeignKey(fk => fk.DiagnosticoId);
        }
    }
}
