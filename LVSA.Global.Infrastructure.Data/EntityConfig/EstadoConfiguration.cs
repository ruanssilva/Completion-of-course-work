using LVSA.Global.Domain;
using System.Data.Entity.ModelConfiguration;

namespace LVSA.Global.Infrastructure.Data.EntityConfig
{
    public class EstadoConfiguration : EntityTypeConfiguration<Estado>
    {
        public EstadoConfiguration()
        {
            ToTable("Estado", "Global");

            HasRequired(rq => rq.Pais)
                .WithMany(m => m.Estados)
                .HasForeignKey(fk => fk.PaisId);
        }
    }
}
