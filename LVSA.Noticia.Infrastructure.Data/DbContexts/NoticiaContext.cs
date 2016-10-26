using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Infrastructure.Data.DbContexts;
using LVSA.Noticia.Infrastructure.Data.EntityConfig;

namespace LVSA.Noticia.Infrastructure.Data.DbContexts
{
    public class NoticiaContext : BaseContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ImagemConfiguration());
            modelBuilder.Configurations.Add(new NoticiaConfiguration());
            modelBuilder.Configurations.Add(new NoticiaImagemConfiguration());
            modelBuilder.Configurations.Add(new NoticiaVisualizadaConfiguration());
            modelBuilder.Configurations.Add(new NoticiaContextoConfiguration());
            modelBuilder.Configurations.Add(new NoticiaAplicacaoConfiguration());
        }
    }
}
