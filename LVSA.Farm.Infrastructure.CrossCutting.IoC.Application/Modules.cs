using LVSA.Farm.Application;
using LVSA.Farm.Application.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Infrastructure.CrossCutting.IoC.Application
{
    public class Modules : NinjectModule
    {
        public override void Load()
        {
            Bind<ITerrenoAppService>().To<TerrenoAppService>();
            Bind<IPastoAppService>().To<PastoAppService>();
            Bind<IPiqueteAppService>().To<PiqueteAppService>();
            Bind<IRetratoAppService>().To<RetratoAppService>();
            Bind<ITipoAnimalAppService>().To<TipoAnimalAppService>();
            Bind<IRacaAppService>().To<RacaAppService>();
            Bind<ITipoMedicamentoAppService>().To<TipoMedicamentoAppService>();
            Bind<IMedicamentoAppService>().To<MedicamentoAppService>();
            Bind<IAnimalAppService>().To<AnimalAppService>();
            Bind<IDoencaAppService>().To<DoencaAppService>();
            Bind<ILocalPesagemAppService>().To<LocalPesagemAppService>();
            Bind<ITratamentoAppService>().To<TratamentoAppService>();
            Bind<IDosagemAppService>().To<DosagemAppService>();
            Bind<IDiagnosticoAppService>().To<DiagnosticoAppService>();
            Bind<IPrescricaoAppService>().To<PrescricaoAppService>();
            Bind<IOrdenhaAppService>().To<OrdenhaAppService>();
        }

    }
}
