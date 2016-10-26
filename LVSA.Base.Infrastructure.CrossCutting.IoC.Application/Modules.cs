using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Application;
using LVSA.Base.Application.Interfaces;

namespace LVSA.Base.Infrastructure.CrossCutting.IoC.Application
{
    public class Modules : NinjectModule
    {
        public override void Load()
        {
            Bind<IReadOnlyAppService>().To<ReadOnlyAppService>();
        }
    }
}
