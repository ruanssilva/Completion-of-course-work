using LVSA.Financial.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Financial.Infrastructure.Data.EntityConfig
{
    public class CategoriaCCustoConfiguration : EntityTypeConfiguration<CategoriaCCusto>
    {
        public CategoriaCCustoConfiguration()
        {
            ToTable("CategoriaCCusto", "Financial");

            Property(p => p.Descricao)
                .HasMaxLength(255);

        }
    }
}
