using LVSA.Report.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Infrastructure.Data.EntityConfig
{
    public class ConsultaParametroConfiguration : EntityTypeConfiguration<ConsultaParametro>
    {
        public ConsultaParametroConfiguration()
        {
            ToTable("ConsultaParametro", "Report");

            HasKey(k => new { k.ConsultaId, k.ParametroId, k.Numero });

            HasRequired(hr => hr.Parametro)
                .WithMany()
                .HasForeignKey(fk => fk.ParametroId);

            HasRequired(hr => hr.Consulta)
                .WithMany()
                .HasForeignKey(fk => fk.ConsultaId)
                .WillCascadeOnDelete(true);
                
        }
    }
}
