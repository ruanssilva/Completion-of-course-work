using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Noticia.Application;
using LVSA.Noticia.Application.Interfaces;

namespace LVSA.Noticia.Infrastructure.CrossCutting.IoC.Application
{
    public class Modules : NinjectModule
    {
        public override void Load()
        {
            Bind<INoticiaAppService>().To<NoticiaAppService>();
        }
    }
}
