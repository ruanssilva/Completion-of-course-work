using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Domain;

namespace LVSA.Security.Infrastructure.Data.EntityConfig
{
    public class AplicacaoAcessoConfiguration : EntityTypeConfiguration<AplicacaoAcesso>
    {
        public AplicacaoAcessoConfiguration()
        {
            ToTable("AplicacaoAcesso", "Security");

            HasRequired(r => r.Aplicacao)
                .WithMany()
                .HasForeignKey(fk => fk.AplicacaoId);
        }
    }
}
