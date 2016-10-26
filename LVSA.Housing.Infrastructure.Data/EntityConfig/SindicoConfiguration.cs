using LVSA.Housing.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Housing.Infrastructure.Data.EntityConfig
{
    public class SindicoConfiguration : EntityTypeConfiguration<Sindico>
    {
        public SindicoConfiguration()
        {
            ToTable("Sindico", "Housing");

            HasRequired(hr => hr.Condominio)
                .WithMany(m => m.Sindicos)
                .HasForeignKey(fk => new { fk.ColigadaId, fk.FilialId });

        }
    }
}
