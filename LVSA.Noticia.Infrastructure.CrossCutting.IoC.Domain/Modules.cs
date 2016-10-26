using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Noticia.Domain.Interfaces.Repository;
using LVSA.Noticia.Domain.Interfaces.Services;
using LVSA.Noticia.Domain.Services;
using LVSA.Noticia.Infrastructure.Data.Repository.EF;

namespace LVSA.Noticia.Infrastructure.CrossCutting.IoC.Domain
{
    public class Modules : NinjectModule
    {
        public override void Load()
        {
            Bind<INoticiaRepository>().To<NoticiaRepository>();
            Bind<INoticiaService>().To<NoticiaService>();
            Bind<INoticiaImagemRepository>().To<NoticiaImagemRepository>();
            Bind<INoticiaImagemService>().To<NoticiaImagemService>();
            Bind<IImagemRepository>().To<ImagemRepository>();
            Bind<IImagemService>().To<ImagemService>();
            Bind<INoticiaVisualizadaRepository>().To<NoticiaVisualizadaRepository>();
            Bind<INoticiaVisualizadaService>().To<NoticiaVisualizadaService>();
            Bind<INoticiaContextoRepository>().To<NoticiaContextoRepository>();
            Bind<INoticiaContextoService>().To<NoticiaContextoService>();
            Bind<INoticiaAplicacaoRepository>().To<NoticiaAplicacaoRepository>();
            Bind<INoticiaAplicacaoService>().To<NoticiaAplicacaoService>();
        }
    }
}
