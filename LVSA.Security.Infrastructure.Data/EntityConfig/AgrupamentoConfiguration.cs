using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Domain;

namespace LVSA.Security.Infrastructure.Data.EntityConfig
{
    public class AgrupamentoConfiguration : EntityTypeConfiguration<Agrupamento>
    {
        public AgrupamentoConfiguration()
        {
            ToTable("Agrupamento", "Security");

            HasKey(k => new { k.GrupoId, k.UsuarioId });

            HasRequired(r => r.Grupo)
                .WithMany()
                .HasForeignKey(fk => fk.GrupoId);

            HasRequired(r => r.Usuario)
                .WithMany()
                .HasForeignKey(fk => fk.UsuarioId);
        }
    }
}
