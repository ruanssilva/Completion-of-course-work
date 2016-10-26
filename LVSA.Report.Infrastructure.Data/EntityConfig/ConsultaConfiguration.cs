using LVSA.Report.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Infrastructure.Data.EntityConfig
{
    public class ConsultaConfiguration : EntityTypeConfiguration<Consulta>
    {
        public ConsultaConfiguration()
        {
            ToTable("Consulta", "Report");

            Property(p => p.Descricao)
                .HasMaxLength(255);

            Property(p => p.TSQL)
                .HasMaxLength(10000)
                .HasColumnType("text");

            HasRequired(r => r.CategoriaConsulta)
                .WithMany()
                .HasForeignKey(fk => fk.CategoriaConsultaId);
                        
        }

    }
}
