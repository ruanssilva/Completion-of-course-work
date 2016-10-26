using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Domain;

namespace LVSA.Security.Infrastructure.Data.EntityConfig
{
    public class ColigadaConfiguration : EntityTypeConfiguration<Coligada>
    {
        public ColigadaConfiguration()
        {
            ToTable("Coligada", "Global");

            HasMany(m => m.FilialSet)
                .WithRequired()
                .HasForeignKey(fk => fk.ColigadaId);
        }
    }
}
