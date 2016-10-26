using LVSA.Farm.Domain.Interfaces.Repository;
using LVSA.Farm.Domain.Interfaces.Services;
using LVSA.Farm.Domain.Services;
using LVSA.Farm.Infrastructure.Data.Repository;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Infrastructure.CrossCutting.IoC.Domain
{
    public class Modules : NinjectModule
    {
        public override void Load()
        {
            Bind<IAnimalRepository>().To<AnimalRepository>();
            Bind<IAnimalService>().To<AnimalService>();

            Bind<IAquisicaoRepository>().To<AquisicaoRepository>();
            Bind<IAquisicaoService>().To<AquisicaoService>();

            Bind<IBaixaRepository>().To<BaixaRepository>();
            Bind<IBaixaService>().To<BaixaService>();

            Bind<IDiagnosticoRepository>().To<DiagnosticoRepository>();
            Bind<IDiagnosticoService>().To<DiagnosticoService>();

            Bind<IDoencaRepository>().To<DoencaRepository>();
            Bind<IDoencaService>().To<DoencaService>();

            Bind<ILocalPesagemRepository>().To<LocalPesagemRepository>();
            Bind<ILocalPesagemService>().To<LocalPesagemService>();

            Bind<IMedicacaoRepository>().To<MedicacaoRepository>();
            Bind<IMedicacaoService>().To<MedicacaoService>();

            Bind<IPastoRepository>().To<PastoRepository>();
            Bind<IPastoService>().To<PastoService>();

            Bind<IPesagemRepository>().To<PesagemRepository>();
            Bind<IPesagemService>().To<PesagemService>();

            Bind<IPiqueteRepository>().To<PiqueteRepository>();
            Bind<IPiqueteService>().To<PiqueteService>();

            Bind<IPrestadorRepository>().To<PrestadorRepository>();
            Bind<IPrestadorService>().To<PrestadorService>();

            Bind<IRacaRepository>().To<RacaRepository>();
            Bind<IRacaService>().To<RacaService>();

            Bind<IRetratoRepository>().To<RetratoRepository>();
            Bind<IRetratoService>().To<RetratoService>();

            Bind<ITerrenoRepository>().To<TerrenoRepository>();
            Bind<ITerrenoService>().To<TerrenoService>();

            Bind<ITipoAnimalRepository>().To<TipoAnimalRepository>();
            Bind<ITipoAnimalService>().To<TipoAnimalService>();

            Bind<IMedicamentoRepository>().To<MedicamentoRepository>();
            Bind<IMedicamentoService>().To<MedicamentoService>();

            Bind<ITipoMedicamentoRepository>().To<TipoMedicamentoRepository>();
            Bind<ITipoMedicamentoService>().To<TipoMedicamentoService>();

            Bind<ITratamentoRepository>().To<TratamentoRepository>();
            Bind<ITratamentoService>().To<TratamentoService>();

            Bind<IDosagemRepository>().To<DosagemRepository>();
            Bind<IDosagemService>().To<DosagemService>();

            Bind<IPrescricaoRepository>().To<PrescricaoRepository>();
            Bind<IPrescricaoService>().To<PrescricaoService>();

            Bind<IOrdenhaRepository>().To<OrdenhaRepository>();
            Bind<IOrdenhaService>().To<OrdenhaService>();

        }
    }
}
