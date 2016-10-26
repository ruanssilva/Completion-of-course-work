using LVSA.Housing.Domain;
using System.Data.Entity.ModelConfiguration;

namespace LVSA.Housing.Infrastructure.Data.EntityConfig
{
    public class MultaConfiguration : EntityTypeConfiguration<Multa>
    {
        public MultaConfiguration()
        {
            ToTable("Multa", "Housing");

            Property(p => p.Descricao)
                .HasMaxLength(255);
        }
    }
}
