using LVSA.Housing.Domain;
using System.Data.Entity.ModelConfiguration;

namespace LVSA.Housing.Infrastructure.Data.EntityConfig
{
    public class AvisoConfiguration : EntityTypeConfiguration<Aviso>
    {
        public AvisoConfiguration()
        {
            ToTable("Aviso", "Housing");

            HasRequired(r => r.Sindico)
                .WithMany()
                .HasForeignKey(fk => fk.SindicoId)
                .WillCascadeOnDelete();
        }
    }
}
