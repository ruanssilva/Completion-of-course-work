using LVSA.Housing.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Housing.Infrastructure.Data.EntityConfig
{
    public class MoradiaConfiguration : EntityTypeConfiguration<Moradia>
    {
        public MoradiaConfiguration()
        {
            ToTable("Moradia", "Housing");

            HasRequired(hr => hr.Condominio)
                .WithMany()
                .HasForeignKey(fk => new { fk.ColigadaId, fk.FilialId });

            HasOptional(o => o.Bloco)
                .WithMany(m=>m.Moradias)
                .HasForeignKey(fk => fk.BlocoId);

            Property(p => p.Descricao)
                .HasMaxLength(255);
        }
    }
}
