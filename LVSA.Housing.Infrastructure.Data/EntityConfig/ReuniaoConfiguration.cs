using LVSA.Housing.Domain;
using System.Data.Entity.ModelConfiguration;

namespace LVSA.Housing.Infrastructure.Data.EntityConfig
{
    public class ReuniaoConfiguration : EntityTypeConfiguration<Reuniao>
    {
        public ReuniaoConfiguration()
        {
            ToTable("Reuniao", "Housing");

            HasRequired(r => r.Sindico)
                .WithMany()
                .HasForeignKey(fk => fk.SindicoId)
                .WillCascadeOnDelete();
        }
    }
}
