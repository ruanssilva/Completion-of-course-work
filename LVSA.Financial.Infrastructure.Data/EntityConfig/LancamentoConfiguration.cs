using LVSA.Financial.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Financial.Infrastructure.Data.EntityConfig
{
    public class LancamentoConfiguration : EntityTypeConfiguration<Lancamento>
    {
        public LancamentoConfiguration()
        {
            ToTable("Lancamento", "Financial");

            HasRequired(hr => hr.CCusto)
                .WithMany()
                .HasForeignKey(fk => fk.CCustoId);

            HasOptional(o => o.NFiscal)
                .WithMany()
                .HasForeignKey(fk => fk.NFiscalId);

            Property(p => p.Descricao)
                .HasMaxLength(255);
        }
    }
}
