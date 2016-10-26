using LVSA.Base.Domain.Services;
using LVSA.Global.Domain.Interfaces.Repository;
using LVSA.Global.Domain.Interfaces.Services;
namespace LVSA.Global.Domain.Services
{
    public class PessoaJuridicaService : ServiceBase<PessoaJuridica>, IPessoaJuridicaService
    {
        public PessoaJuridicaService(IPessoaJuridicaRepository repository)
            : base(repository)
        {
        }
    }
}
