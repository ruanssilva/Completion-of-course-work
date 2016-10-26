
using LVSA.Global.Domain;
using System.Data.Entity.ModelConfiguration;
namespace LVSA.Global.Infrastructure.Data.EntityConfig
{
    public class EscolaridadeConfiguration : EntityTypeConfiguration<Escolaridade>
    {
        public EscolaridadeConfiguration()
        {
            ToTable("Escolaridade", "Global");
        }
    }
}
