using LVSA.Farm.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Infrastructure.Data.EntityConfig
{
    public class MedicamentoConfiguration : EntityTypeConfiguration<Medicamento>
    {
        public MedicamentoConfiguration()
        {
            ToTable("Medicamento", "Farm");

            HasRequired(hr => hr.TipoMedicamento)
                .WithMany()
                .HasForeignKey(fk => fk.TipoMedicamentoId);
        }
    }
}
