using LVSA.Report.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Infrastructure.Data.EntityConfig
{
    public class InstrucaoConfiguration : EntityTypeConfiguration<Instrucao>
    {
        public InstrucaoConfiguration()
        {
            ToTable("Instrucao", "Report");

            Property(p => p.Descricao)
                .HasMaxLength(255);

            Property(p => p.Code)
                .HasMaxLength(10000)
                .HasColumnType("text");

            HasRequired(hr => hr.CategoriaInstrucao)
                .WithMany()
                .HasForeignKey(fk => fk.CategoriaInstrucaoId);
        }
    }
}
