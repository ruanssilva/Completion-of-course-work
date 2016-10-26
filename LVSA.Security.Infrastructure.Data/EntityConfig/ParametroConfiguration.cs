using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Domain;

namespace LVSA.Security.Infrastructure.Data.EntityConfig
{
    public class ParametroConfiguration : EntityTypeConfiguration<Parametro>
    {
        public ParametroConfiguration()
        {
            ToTable("Parametro", "Security");

            Property(p => p.Type)
                .HasColumnName("Tipo");

            Property(p => p.TSQL)
                .HasMaxLength(8000);
        }
    }
}
