using LVSA.Report.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Infrastructure.Data.EntityConfig
{
    public class GrupoConfiguration : EntityTypeConfiguration<Grupo>
    {
        public GrupoConfiguration()
        {
            ToTable("Grupo", "Report");

            Property(p => p.Descricao)
                .HasMaxLength(255);
        }
    }
}
