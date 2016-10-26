using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Domain;

namespace LVSA.Security.Infrastructure.Data.EntityConfig
{
    public class UsuarioFilialConfiguration : EntityTypeConfiguration<UsuarioFilial>
    {
        public UsuarioFilialConfiguration()
        {
            ToTable("UsuarioFilial", "Security");

            HasKey(k => new { k.UsuarioId, k.ColigadaId, k.FilialId });

            HasRequired(r => r.Coligada)
                .WithMany()
                .HasForeignKey(fk => fk.ColigadaId);

            HasRequired(r => r.Filial)
                .WithMany()
                .HasForeignKey(fk => fk.FilialId);

            HasRequired(r => r.Usuario)
                .WithMany()
                .HasForeignKey(fk => fk.UsuarioId);
        }
    }
}
