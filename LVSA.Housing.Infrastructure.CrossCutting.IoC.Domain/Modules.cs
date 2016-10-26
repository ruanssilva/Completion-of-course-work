using LVSA.Housing.Domain.Interfaces.Repository;
using LVSA.Housing.Domain.Interfaces.Services;
using LVSA.Housing.Domain.Services;
using LVSA.Housing.Infrastructure.Data.Repository.EF;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Housing.Infrastructure.CrossCutting.IoC.Domain
{
    public class Modules : NinjectModule
    {
        public override void Load()
        {
            //Condominio
            Bind<ICondominioRepository>().To<CondominioRepository>();
            Bind<ICondominioService>().To<CondominioService>();
            //Bloco
            Bind<IBlocoRepository>().To<BlocoRepository>();
            Bind<IBlocoService>().To<BlocoService>();
            //Moradia
            Bind<IMoradiaRepository>().To<MoradiaRepository>();
            Bind<IMoradiaService>().To<MoradiaService>();
            //Morador
            Bind<IMoradorRepository>().To<MoradorRepository>();
            Bind<IMoradorService>().To<MoradorService>();
            //Sindico
            Bind<ISindicoRepository>().To<SindicoRepository>();
            Bind<ISindicoService>().To<SindicoService>();
            //CustoMoradia
            Bind<ICustoMoradiaRepository>().To<CustoMoradiaRepository>();
            Bind<ICustoMoradiaService>().To<CustoMoradiaService>();
            //Aviso
            Bind<IAvisoRepository>().To<AvisoRepository>();
            Bind<IAvisoService>().To<AvisoService>();
            //Multa
            Bind<IMultaRepository>().To<MultaRepository>();
            Bind<IMultaService>().To<MultaService>();
            //MultaMorador
            Bind<IMultaMoradorRepository>().To<MultaMoradorRepository>();
            Bind<IMultaMoradorService>().To<MultaMoradorService>();
            //Reuniao
            Bind<IReuniaoRepository>().To<ReuniaoRepository>();
            Bind<IReuniaoService>().To<ReuniaoService>();
            //Presenca
            Bind<IPresencaRepository>().To<PresencaRepository>();
            Bind<IPresencaService>().To<PresencaService>();
        }
    }
}
