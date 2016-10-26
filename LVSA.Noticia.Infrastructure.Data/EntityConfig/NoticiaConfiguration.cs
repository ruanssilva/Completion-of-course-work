using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Noticia.Domain;

namespace LVSA.Noticia.Infrastructure.Data.EntityConfig
{
    public class NoticiaConfiguration : EntityTypeConfiguration<LVSA.Noticia.Domain.Noticia>
    {
        public NoticiaConfiguration()
        {
            ToTable("Noticia", "Noticia");

            Property(p => p.Texto)
                .HasMaxLength(8000);

            HasMany(m => m.NoticiaImagemSet)
                .WithRequired()
                .HasForeignKey(fk => fk.NoticiaId);

            HasMany(m => m.NoticiaVisualizadaSet)
                .WithRequired()
                .HasForeignKey(fk => fk.NoticiaId);

            Property(p => p.Tags)
                .HasMaxLength(255);
        }
    }
}
