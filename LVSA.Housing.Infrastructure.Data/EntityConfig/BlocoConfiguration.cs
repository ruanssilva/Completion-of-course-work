using LVSA.Housing.Domain;
using System.Data.Entity.ModelConfiguration;

namespace LVSA.Housing.Infrastructure.Data.EntityConfig
{
    public class BlocoConfiguration : EntityTypeConfiguration<Bloco>
    {
        public BlocoConfiguration()
        {
            ToTable("Bloco", "Housing");

            HasRequired(hr => hr.Condominio)
                .WithMany(m => m.Blocos)
                .HasForeignKey(fk => new { fk.ColigadaId, fk.FilialId });

            HasOptional(o => o.Sindico)
                .WithMany(m => m.Blocos)
                .HasForeignKey(fk => new { fk.SindicoId });
        }
    }
}
