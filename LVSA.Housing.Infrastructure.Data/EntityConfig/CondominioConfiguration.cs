using LVSA.Housing.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Housing.Infrastructure.Data.EntityConfig
{
    public class CondominioConfiguration : EntityTypeConfiguration<Condominio>
    {
        public CondominioConfiguration()
        {
            ToTable("Condominio", "Housing");

            HasKey(k => new { k.ColigadaId, k.FilialId });
        }
    }
}
