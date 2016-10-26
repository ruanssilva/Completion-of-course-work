using LVSA.Financial.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Financial.Infrastructure.Data.EntityConfig
{
    public class TipoContaConfiguration : EntityTypeConfiguration<TipoConta>
    {
        public TipoContaConfiguration()
        {
            ToTable("TipoConta", "Financial");

            Property(p => p.Codigo)
                .HasMaxLength(2);
        }
    }
}
