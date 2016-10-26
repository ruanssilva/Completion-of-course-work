using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Domain;

namespace LVSA.Security.Infrastructure.Data.EntityConfig
{
    public class FilialConfiguration : EntityTypeConfiguration<Filial>
    {
        public FilialConfiguration()
        {
            ToTable("Filial", "Global");

            HasRequired(r => r.Coligada)
                .WithMany()
                .HasForeignKey(fk => fk.ColigadaId);
        }
    }
}
