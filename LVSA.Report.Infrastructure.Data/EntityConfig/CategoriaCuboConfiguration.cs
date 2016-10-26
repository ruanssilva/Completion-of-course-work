using LVSA.Report.Domain;
using System.Data.Entity.ModelConfiguration;

namespace LVSA.Report.Infrastructure.Data.EntityConfig
{
    public class CategoriaCuboConfiguration : EntityTypeConfiguration<CategoriaCubo>
    {
        public CategoriaCuboConfiguration()
        {
            ToTable("CategoriaCubo", "Report");
        }
    }
}
