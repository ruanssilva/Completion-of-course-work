using LVSA.Global.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Global.Infrastructure.Data.EntityConfig
{
    public class PaisConfiguration : EntityTypeConfiguration<Pais>
    {
        public PaisConfiguration()
        {
            ToTable("Pais", "Global");
        }
    }
}
