using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Domain;

namespace LVSA.Security.Infrastructure.Data.EntityConfig
{
    public class ParametrizacaoConfiguration : EntityTypeConfiguration<Parametrizacao>
    {
        public ParametrizacaoConfiguration()
        {
            ToTable("Parametrizacao", "Security");

            HasKey(k => new { k.AplicacaoId, k.ParametroId, k.Codigo });

            HasRequired(r => r.Aplicacao)
                .WithMany()
                .HasForeignKey(fk => fk.AplicacaoId);

            HasRequired(r => r.Parametro)
                .WithMany()
                .HasForeignKey(fk => fk.ParametroId);
        }
    }
}
