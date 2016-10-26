using LVSA.Report.Domain;
using System.Data.Entity.ModelConfiguration;

namespace LVSA.Report.Infrastructure.Data.EntityConfig
{
    public class CategoriaInstrucaoConfiguration : EntityTypeConfiguration<CategoriaInstrucao>
    {
        public CategoriaInstrucaoConfiguration()
        {
            ToTable("CategoriaInstrucao", "Report");
        }
    }
}
