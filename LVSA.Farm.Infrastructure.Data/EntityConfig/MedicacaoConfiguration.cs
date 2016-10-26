using LVSA.Farm.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Infrastructure.Data.EntityConfig
{
    public class MedicacaoConfiguration : EntityTypeConfiguration<Medicacao>
    {
        public MedicacaoConfiguration()
        {
            ToTable("Medicacao", "Farm");

            HasRequired(r => r.Medicamento)
                .WithMany()
                .HasForeignKey(fk => fk.MedicamentoId);

            HasOptional(ho => ho.Doenca)
                .WithMany()
                .HasForeignKey(fk => fk.DoencaId);
        }
    }
}
