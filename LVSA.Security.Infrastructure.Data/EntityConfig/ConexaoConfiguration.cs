using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Domain;

namespace LVSA.Security.Infrastructure.Data.EntityConfig
{
    public class ConexaoConfiguration : EntityTypeConfiguration<Conexao>
    {
        public ConexaoConfiguration()
        {
            ToTable("Conexao", "Security");

            Property(p => p.Codigo)
                .HasMaxLength(1)
                .IsRequired();

            Property(p => p.ConnectionString)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
