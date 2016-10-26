using LVSA.Global.Application.ViewModels;
using LVSA.Global.Domain;

namespace LVSA.Global.Application.Interfaces
{
    public interface IPessoaFisicaAppService : IAppServiceBase<PessoaFisicaViewModel,PessoaFisica>
    {
        PessoaFisicaViewModel ObterPorId(int id);
    }
}
