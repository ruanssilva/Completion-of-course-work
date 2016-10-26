using LVSA.Report.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Infrastructure.Data.EntityConfig
{
    public class CuboParametroConfiguration : EntityTypeConfiguration<CuboParametro>
    {
        public CuboParametroConfiguration()
        {
            ToTable("CuboParametro", "Report");

            HasKey(k => new { k.CuboId, k.Numero });

            HasRequired(r => r.Cubo)
                .WithMany()
                .HasForeignKey(fk => fk.CuboId)
                .WillCascadeOnDelete();

        }
    }
}
