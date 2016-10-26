using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Application.ViewModels;
using LVSA.Security.Domain;

namespace LVSA.Security.Application.Interfaces
{
    public interface IAplicacaoAppService : IAppServiceBase<AplicacaoViewModel, Aplicacao>
    {
        AplicacaoViewModel ObterPorId(int id);
        void Parametrizar(AplicacaoViewModel aplicacao, ParametroViewModel parametro);
        void Desparametrizar(AplicacaoViewModel aplicacao, ParametroViewModel parametro);
    }
}
