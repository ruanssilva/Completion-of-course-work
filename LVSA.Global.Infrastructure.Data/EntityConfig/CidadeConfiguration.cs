using LVSA.Global.Domain;
using System.Data.Entity.ModelConfiguration;

namespace LVSA.Global.Infrastructure.Data.EntityConfig
{
    public class CidadeConfiguration :EntityTypeConfiguration<Cidade>
    {
        public CidadeConfiguration()
        {
            ToTable("Cidade", "Global");

            HasRequired(ho => ho.Estado)
                .WithMany(m => m.Cidades)
                .HasForeignKey(fk => fk.EstadoId);
                
        }
    }
}
