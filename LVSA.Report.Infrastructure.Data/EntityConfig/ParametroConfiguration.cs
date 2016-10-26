using LVSA.Report.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Infrastructure.Data.EntityConfig
{
    public class ParametroConfiguration : EntityTypeConfiguration<Parametro>
    {
        public ParametroConfiguration()
        {
            ToTable("Parametro", "Report");

            Property(p => p.Consulta)
                .HasMaxLength(10000)
                .HasColumnType("text");
        }
    }
}
