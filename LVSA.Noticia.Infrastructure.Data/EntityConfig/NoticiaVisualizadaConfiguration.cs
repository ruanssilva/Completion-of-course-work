using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Noticia.Domain;

namespace LVSA.Noticia.Infrastructure.Data.EntityConfig
{
    public class NoticiaVisualizadaConfiguration : EntityTypeConfiguration<NoticiaVisualizada>
    {
        public NoticiaVisualizadaConfiguration()
        {
            ToTable("NoticiaVisualizada", "Noticia");

            HasKey(k => new { k.UsuarioId, k.NoticiaId });

            HasRequired(r => r.Noticia)
                .WithMany()
                .HasForeignKey(fk => fk.NoticiaId);
        }
    }
}
