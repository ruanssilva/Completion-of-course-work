using LVSA.Report.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Infrastructure.Data.EntityConfig
{
    public class CuboConfiguration : EntityTypeConfiguration<Cubo>
    {
        public CuboConfiguration()
        {
            ToTable("Cubo", "Report");

            Property(p => p.Descricao)
                .HasMaxLength(255);

            HasRequired(hr => hr.Instrucao)
                .WithMany(m => m.Cubos)
                .HasForeignKey(fk => fk.InstrucaoId);

            HasRequired(hr => hr.Consulta)
                .WithMany(m => m.Cubos)
                .HasForeignKey(fk => fk.ConsultaId);

            HasRequired(hr => hr.CategoriaCubo)
                .WithMany()
                .HasForeignKey(fk => fk.CategoriaCuboId);
        }
    }
}
