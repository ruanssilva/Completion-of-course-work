using LVSA.Financial.Application;
using LVSA.Financial.Application.Interfaces;
using Ninject.Modules;

namespace LVSA.Financial.Infrastructure.CrossCutting.IoC.Application
{
    public class Modules : NinjectModule
    {
        public override void Load()
        {
            //CCusto
            Bind<ICCustoAppService>().To<CCustoAppService>();
            //CategoriaCCusto
            Bind<ICategoriaCCustoAppService>().To<CategoriaCCustoAppService>();
            //Lancamento
            Bind<ILancamentoAppService>().To<LancamentoAppService>();
            //NFiscal
            Bind<INFiscalAppService>().To<NFiscalAppService>();
            //TipoConta
            Bind<ITipoContaAppService>().To<TipoContaAppService>();
            //Conta
            Bind<IContaAppService>().To<ContaAppService>();
        }
    }
}
