using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Domain;

namespace LVSA.Security.Infrastructure.Data.EntityConfig
{
    public class GrupoConfiguration : EntityTypeConfiguration<Grupo>
    {
        public GrupoConfiguration()
        {
            ToTable("Grupo", "Security");

            HasOptional(o => o.Aplicacao)
                .WithMany(m=>m.GrupoSet)
                .HasForeignKey(fk => fk.AplicacaoId);

            HasMany(m => m.AgrupamentoSet)
                .WithRequired()
                .HasForeignKey(fk => fk.GrupoId);

            HasMany(m => m.PermissaoSet)
                .WithOptional()
                .HasForeignKey(fk => fk.GrupoId);
        }
    }
}
