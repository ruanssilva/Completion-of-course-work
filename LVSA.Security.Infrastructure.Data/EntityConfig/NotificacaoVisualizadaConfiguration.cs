using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Domain;

namespace LVSA.Security.Infrastructure.Data.EntityConfig
{
    public class NotificacaoVisualizadaConfiguration : EntityTypeConfiguration<NotificacaoVisualizada>
    {
        public NotificacaoVisualizadaConfiguration()
        {
            ToTable("NotificacaoVisualizada", "Security");

            HasKey(k => new { k.NotificacaoId, k.UsuarioId });

            HasRequired(r => r.Usuario)
                .WithMany()
                .HasForeignKey(fk => fk.UsuarioId);

            HasRequired(r => r.Notificacao)
                .WithMany()
                .HasForeignKey(fk => fk.NotificacaoId);
        }
    }
}
