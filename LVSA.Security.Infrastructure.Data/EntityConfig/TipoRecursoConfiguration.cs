using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Domain;

namespace LVSA.Security.Infrastructure.Data.EntityConfig
{
    public class TipoRecursoConfiguration : EntityTypeConfiguration<TipoRecurso>
    {
        public TipoRecursoConfiguration()
        {
            ToTable("TipoRecurso", "Security");

            Property(p => p.Codigo)
                .IsRequired()
                .HasMaxLength(8);

            Property(p => p.Nome)
                .IsRequired();
        }
    }
}
