using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Noticia.Domain;

namespace LVSA.Noticia.Infrastructure.Data
{
    public class NoticiaAplicacaoConfiguration : EntityTypeConfiguration<NoticiaAplicacao>
    {
        public NoticiaAplicacaoConfiguration()
        {
            ToTable("NoticiaAplicacao", "Noticia");

            HasKey(k => new
            {
                k.AplicacaoId,
                k.NoticiaId
            });
        }
    }
}
