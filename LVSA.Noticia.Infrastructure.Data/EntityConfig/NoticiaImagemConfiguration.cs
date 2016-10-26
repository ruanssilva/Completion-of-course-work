using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Noticia.Domain;

namespace LVSA.Noticia.Infrastructure.Data.EntityConfig
{
    public class NoticiaImagemConfiguration : EntityTypeConfiguration<NoticiaImagem>
    {
        public NoticiaImagemConfiguration()
        {
            ToTable("NoticiaImagem", "Noticia");

            HasKey(k => new { k.NoticiaId, k.ImagemId });

            HasRequired(r => r.Imagem)
                .WithMany()
                .HasForeignKey(f => f.ImagemId);

            HasRequired(r => r.Noticia)
                .WithMany()
                .HasForeignKey(f => f.NoticiaId);
        }
    }
}
