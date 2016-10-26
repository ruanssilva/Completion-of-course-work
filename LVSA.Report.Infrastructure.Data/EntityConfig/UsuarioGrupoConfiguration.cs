using LVSA.Report.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Infrastructure.Data.EntityConfig
{
    public class UsuarioGrupoConfiguration : EntityTypeConfiguration<UsuarioGrupo>
    {
        public UsuarioGrupoConfiguration()
        {
            ToTable("UsuarioGrupo", "Report");

            HasKey(k => new { k.GrupoId, k.UsuarioId });

            HasRequired(hr => hr.Grupo)
                .WithMany()
                .HasForeignKey(fk => fk.GrupoId);
        }
    }
}
