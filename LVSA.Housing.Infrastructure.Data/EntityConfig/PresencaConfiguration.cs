using LVSA.Housing.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Housing.Infrastructure.Data.EntityConfig
{
    public class PresencaConfiguration : EntityTypeConfiguration<Presenca>
    {
        public PresencaConfiguration()
        {
            ToTable("Presenca", "Housing");

            HasKey(hk => new { hk.MoradorId, hk.ReuniaoId });
        }
    }
}
