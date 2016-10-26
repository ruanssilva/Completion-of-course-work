using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Noticia.Domain;

namespace LVSA.Noticia.Infrastructure.Data.EntityConfig
{
    public class NoticiaContextoConfiguration : EntityTypeConfiguration<NoticiaContexto>
    {
        public NoticiaContextoConfiguration()
        {
            ToTable("NoticiaContexto", "Noticia");

            HasKey(k => new
            {
                k.NoticiaId,
                ColigadaId = k.ColigadaId,
                FilialId = k.FilialId
            });
        }
    }
}
