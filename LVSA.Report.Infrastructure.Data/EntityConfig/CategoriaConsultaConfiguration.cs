using LVSA.Report.Domain;
using System.Data.Entity.ModelConfiguration;

namespace LVSA.Report.Infrastructure.Data.EntityConfig
{
    public class CategoriaConsultaConfiguration : EntityTypeConfiguration<CategoriaConsulta>
    {
        public CategoriaConsultaConfiguration()
        {
            ToTable("CategoriaConsulta", "Report");
        }
    }
}
