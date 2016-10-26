using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Domain;

namespace LVSA.Security.Infrastructure.Data.EntityConfig
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            ToTable("Usuario", "Security");

            HasOptional(o => o.TipoUsuario)
                .WithMany()
                .HasForeignKey(fk => fk.TipoUsuarioId);

            HasMany(m => m.AgrupamentoSet)
                .WithRequired()
                .HasForeignKey(f => f.UsuarioId);

            HasMany(m => m.PermissaoSet)
                .WithOptional()
                .HasForeignKey(fk => fk.UsuarioId);

        }
    }
}
