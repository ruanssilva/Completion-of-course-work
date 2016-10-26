using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Domain;

namespace LVSA.Security.Infrastructure.Data.EntityConfig
{
    public class PerfilContextoConfiguration : EntityTypeConfiguration<PerfilContexto>
    {
        public PerfilContextoConfiguration()
        {
            ToTable("PerfilContexto", "Security");

            HasKey(k => new { k.AplicacaoId, k.UsuarioId });

            HasRequired(r => r.Usuario)
                .WithMany()
                .HasForeignKey(fk => fk.UsuarioId);

            HasRequired(r => r.Aplicacao)
                .WithMany()
                .HasForeignKey(fk => fk.AplicacaoId);
        }
    }
}
