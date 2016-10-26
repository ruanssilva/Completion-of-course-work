using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Application.ViewModels;
using LVSA.Security.Domain;

namespace LVSA.Security.Application.Interfaces
{
    public interface IUsuarioAppService : IAppServiceBase<UsuarioViewModel, Usuario>
    {
        IEnumerable<UsuarioViewModel> Buscar(Expression<Func<Usuario, bool>> predicate);
        IEnumerable<UsuarioViewModel> ObterPorNome(string nome);
        UsuarioViewModel ObterPorCodigo(string codigo);
        UsuarioViewModel ObterPorCodigo(string codigo, bool filiais = false);
        UsuarioViewModel ObterPorId(long id);
        UsuarioViewModel ObterPorId(long id, bool filiais = false);
        void Agrupar(UsuarioViewModel model);
        void AtualizarCodigo(string codigo);
        void AtualizarAvatar(byte[] imagem);
    }
}
