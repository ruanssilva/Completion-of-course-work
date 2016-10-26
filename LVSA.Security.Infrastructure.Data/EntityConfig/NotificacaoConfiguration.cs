using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Domain;

namespace LVSA.Security.Infrastructure.Data.EntityConfig
{
    public class NotificacaoConfiguration : EntityTypeConfiguration<Notificacao>
    {
        public NotificacaoConfiguration()
        {
            ToTable("Notificacao", "Security");

            HasKey(k => k.Id);

            Property(p => p.Mensagem)
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.Icon)
                .HasColumnName("Icone");

            Property(p => p.Codigo)
                .IsRequired();

            HasOptional(o => o.Aplicacao)
                .WithMany()
                .HasForeignKey(fk => fk.AplicacaoId);

            HasOptional(o => o.Grupo)
                .WithMany()
                .HasForeignKey(fk => fk.GrupoId);

            HasOptional(o => o.Usuario)
                .WithMany()
                .HasForeignKey(fk => fk.UsuarioId);
        }
    }
}
