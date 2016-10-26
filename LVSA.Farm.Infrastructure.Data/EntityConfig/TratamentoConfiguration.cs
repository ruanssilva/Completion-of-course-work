using LVSA.Farm.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Infrastructure.Data.EntityConfig
{
    public class TratamentoConfiguration : EntityTypeConfiguration<Tratamento>
    {
        public TratamentoConfiguration()
        {
            ToTable("Tratamento", "Farm");

            HasOptional(ho => ho.Doenca)
                .WithMany()
                .HasForeignKey(fk => fk.DoencaId);

            HasMany(hm => hm.DosagemSet)
                .WithRequired()
                .HasForeignKey(fk => fk.TratamentoId);
        }
    }
}
