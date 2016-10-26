using LVSA.Housing.Application;
using LVSA.Housing.Application.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Housing.Infrastructure.CrossCutting.IoC.Application
{
    public class Modules : NinjectModule
    {
        public override void Load()
        {
            //Condominio
            Bind<ICondominioAppService>().To<CondominioAppService>();
            //Moradia
            Bind<IMoradiaAppService>().To<MoradiaAppService>();
            //Morador
            Bind<IMoradorAppService>().To<MoradorAppService>();
            //Bloco
            Bind<IBlocoAppService>().To<BlocoAppService>();
            //Sindico
            Bind<ISindicoAppService>().To<SindicoAppService>();
            //CustoMoradia
            Bind<ICustoMoradiaAppService>().To<CustoMoradiaAppService>();
            //Aviso
            Bind<IAvisoAppService>().To<AvisoAppService>();
            //Reuniao
            Bind<IReuniaoAppService>().To<ReuniaoAppService>();
            //Multa
            Bind<IMultaAppService>().To<MultaAppService>();
            //MultaMorador
            Bind<IMultaMoradorAppService>().To<MultaMoradorAppService>();
        }
    }
}
