using LVSA.Housing.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Housing.Infrastructure.Data.EntityConfig
{
    public class MoradorConfiguration : EntityTypeConfiguration<Morador>
    {
        public MoradorConfiguration()
        {
            ToTable("Morador", "Housing");

            HasRequired(hr => hr.Moradia)
                .WithMany(m => m.Moradores)
                .HasForeignKey(fk => fk.MoradiaId);

            HasRequired(hr => hr.Condominio)
                .WithMany()
                .HasForeignKey(fk => new { fk.ColigadaId, fk.FilialId });


        }
    }
}
