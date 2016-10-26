using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Domain;

namespace LVSA.Security.Infrastructure.Data.EntityConfig
{
    public class AplicacaoConfiguration : EntityTypeConfiguration<Aplicacao>
    {
        public AplicacaoConfiguration()
        {
            ToTable("Aplicacao", "Security");

            Property(p => p.Sigla)
                .HasMaxLength(8)
                .IsRequired();

            Property(p => p.Icon)
                .HasColumnName("Icone");

            Property(p => p.Nome)
                .IsRequired();

            Property(p => p.Exibicao)
                .IsRequired();

            Property(p => p.Descricao)
                .IsRequired();

            Property(p => p.Logo)
                .HasMaxLength(8000);

            Property(p => p.Link)
                .HasMaxLength(255);

            HasMany(m => m.ParametrizacaoSet)
                .WithRequired()
                .HasForeignKey(fk => fk.AplicacaoId);

            HasMany(m => m.RecursoSet)
                .WithRequired()
                .HasForeignKey(fk => fk.AplicacaoId);

            HasMany(m => m.AplicacaoDependenciaSet)
                .WithRequired()
                .HasForeignKey(fk => fk.AplicacaoId);

            HasMany(m => m.AplicacaoDependenteSet)
                .WithRequired()
                .HasForeignKey(fk => fk.AplicacaoDependenteId);

        }
    }
}
