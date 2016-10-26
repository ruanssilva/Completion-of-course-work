using LVSA.Social.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Social.Infrastructure.Data.EntityConfig
{
    public class MensagemConfiguration : EntityTypeConfiguration<Mensagem>
    {
        public MensagemConfiguration()
        {
            ToTable("Mensagem", "Social");

            Property(p => p.Texto)
                .HasMaxLength(1000000);
        }
    }
}
