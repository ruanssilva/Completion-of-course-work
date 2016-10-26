using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Application.Models;
using LVSA.Security.Application.ViewModels;
using LVSA.Security.Domain;

namespace LVSA.Security.Application.Interfaces
{
    public interface IContextoAppService
    {
        void SetSeguranca(Seguranca seguranca);
        IEnumerable<ColigadaViewModel> ObterTodasColigada();
        IEnumerable<FilialViewModel> ObterTodasFilial();

        IEnumerable<AplicacaoViewModel> Acessos(Expression<Func<AplicacaoAcesso, bool>> predicate);
        void Conceder(FilialViewModel model);
    }
}
