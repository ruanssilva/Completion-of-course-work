
using LVSA.Global.Domain;
using System.Data.Entity.ModelConfiguration;
namespace LVSA.Global.Infrastructure.Data.EntityConfig
{
    public class TitulacaoConfiguration : EntityTypeConfiguration<Titulacao>
    {
        public TitulacaoConfiguration()
        {
            ToTable("Titulacao", "Global");
        }
    }
}
