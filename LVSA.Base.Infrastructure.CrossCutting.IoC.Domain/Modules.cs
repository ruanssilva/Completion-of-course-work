using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain.Interfaces.Repository.ReadOnly;
using LVSA.Base.Domain.Interfaces.Services;
using LVSA.Base.Domain.Services;
using LVSA.Base.Infrastructure.Data.Repository.Dapper;

namespace LVSA.Base.Infrastructure.CrossCutting.IoC.Domain
{
    public class Modules : NinjectModule
    {
        public override void Load()
        {
            Bind<IReadOnlyRepository>().To<ReadOnlyRepository>();
            Bind<IReadOnlyService>().To<ReadOnlyService>();
        }
    }
}
