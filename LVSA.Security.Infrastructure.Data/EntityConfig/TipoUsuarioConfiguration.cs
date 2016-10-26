using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Domain;

namespace LVSA.Security.Infrastructure.Data.EntityConfig
{
    public class TipoUsuarioConfiguration : EntityTypeConfiguration<TipoUsuario>
    {
        public TipoUsuarioConfiguration()
        {
            ToTable("TipoUsuario", "Security");

            Property(p => p.Nome)
                .IsRequired();

            Property(p => p.Codigo)
                .HasMaxLength(8)
                .IsRequired();

        }
    }
}
