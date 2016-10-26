using LVSA.Farm.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Infrastructure.Data.EntityConfig
{
    public class DosagemConfiguration : EntityTypeConfiguration<Dosagem>
    {
        public DosagemConfiguration()
        {
            ToTable("Dosagem", "Farm");

            HasRequired(hr => hr.Medicamento)
                .WithMany()
                .HasForeignKey(fk => fk.MedicamentoId);

            HasRequired(hr => hr.Tratamento)
                .WithMany()
                .HasForeignKey(fk => fk.TratamentoId);
        }
    }
}
