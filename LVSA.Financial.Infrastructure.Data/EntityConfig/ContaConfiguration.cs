using LVSA.Financial.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Financial.Infrastructure.Data.EntityConfig
{
   public class ContaConfiguration : EntityTypeConfiguration<Conta>
    {
        public ContaConfiguration()
        {
            ToTable("Conta", "Financial");

            HasRequired(hr => hr.TipoConta)
                .WithMany()
                .HasForeignKey(fk => fk.TipoContaId);

            HasMany(hm => hm.CCustoSet)
                .WithOptional()
                .HasForeignKey(fk => fk.ContaId);
        }
    }
}
