using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Domain;

namespace LVSA.Security.Infrastructure.Data.EntityConfig
{
    public class AplicacaoDependenciaConfiguration : EntityTypeConfiguration<AplicacaoDependencia>
    {
        public AplicacaoDependenciaConfiguration()
        {
            ToTable("AplicacaoDependencia", "Security");

            HasKey(k => new { k.AplicacaoId, k.AplicacaoDependenteId });

            HasRequired(r => r.Aplicacao)
                .WithMany()
                .HasForeignKey(fk => fk.AplicacaoId);

            HasRequired(r => r.AplicacaoDependente)
                .WithMany()
                .HasForeignKey(fk => fk.AplicacaoDependenteId);
        }
    }
}
