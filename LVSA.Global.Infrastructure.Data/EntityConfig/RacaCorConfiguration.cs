
using LVSA.Global.Domain;
using System.Data.Entity.ModelConfiguration;
namespace LVSA.Global.Infrastructure.Data.EntityConfig
{
    public class RacaCorConfiguration : EntityTypeConfiguration<RacaCor>
    {
        public RacaCorConfiguration()
        {
            ToTable("RacaCor", "Global");
        }
    }
}
