using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Noticia.Domain;

namespace LVSA.Noticia.Infrastructure.Data.EntityConfig
{
    public class ImagemConfiguration : EntityTypeConfiguration<Imagem>
    {
        public ImagemConfiguration()
        {
            ToTable("Imagem", "Noticia");

            

        }
    }
}
