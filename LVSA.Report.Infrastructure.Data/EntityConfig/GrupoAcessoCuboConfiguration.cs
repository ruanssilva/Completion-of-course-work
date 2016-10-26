using LVSA.Report.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Infrastructure.Data.EntityConfig
{
    public class GrupoAcessoCuboConfiguration : EntityTypeConfiguration<GrupoAcessoCubo>
    {
        public GrupoAcessoCuboConfiguration()
        {
            ToTable("GrupoAcessoCubo", "Report");

            HasKey(k => new { k.CuboId, k.GrupoId });
        }
    }
}
