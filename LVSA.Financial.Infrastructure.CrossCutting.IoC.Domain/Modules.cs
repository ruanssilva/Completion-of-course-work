using LVSA.Financial.Domain.Interfaces.Repository;
using LVSA.Financial.Domain.Interfaces.Services;
using LVSA.Financial.Domain.Services;
using LVSA.Financial.Infrastructure.Data.Repository.EF;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Financial.Infrastructure.CrossCutting.IoC.Domain
{
    public class Modules : NinjectModule
    {
        public override void Load()
        {
            //CCusto
            Bind<ICCustoRepository>().To<CCustoRepository>();
            Bind<ICCustoService>().To<CCustoService>();
            //CategoriaCCusto
            Bind<ICategoriaCCustoRepository>().To<CategoriaCCustoRepository>();
            Bind<ICategoriaCCustoService>().To<CategoriaCCustoService>();
            //NFiscal
            Bind<INFiscalRepository>().To<NFiscalRepository>();
            Bind<INFiscalService>().To<NFiscalService>();
            //Lancamento
            Bind<ILancamentoRepository>().To<LancamentoRepository>();
            Bind<ILancamentoService>().To<LancamentoService>();
            //TipoConta
            Bind<ITipoContaRepository>().To<TipoContaRepository>();
            Bind<ITipoContaService>().To<TipoContaService>();
            //Conta
            Bind<IContaRepository>().To<ContaRepository>();
            Bind<IContaService>().To<ContaService>();
        }
    }
}
