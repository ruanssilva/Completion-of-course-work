using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Domain;

namespace LVSA.Security.Infrastructure.Data.EntityConfig
{
    public class RecursoConfiguration : EntityTypeConfiguration<Recurso>
    {
        public RecursoConfiguration()
        {
            ToTable("Recurso", "Security");

            HasRequired(r => r.TipoRecurso)
                .WithMany()
                .HasForeignKey(fk => fk.TipoRecursoId);

            Property(p => p.Icon)
                .HasColumnName("Icone");

            HasRequired(r => r.Aplicacao)
                .WithMany()
                .HasForeignKey(fk => fk.AplicacaoId);

            HasOptional(o => o.RecursoPai)
                .WithMany(m => m.RecursoSet)
                .HasForeignKey(fk => fk.RecursoPaiId);

            Property(p => p.Nome)
                .IsRequired();

            Property(p => p.Tags)
                .HasMaxLength(255);
        }
    }
}
