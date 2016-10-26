using LVSA.Base.Domain.Services;
using LVSA.Global.Domain.Interfaces.Repository;
using LVSA.Global.Domain.Interfaces.Services;

namespace LVSA.Global.Domain.Services
{
    public class PessoaFisicaComplementoService : ServiceBase<PessoaFisicaComplemento>, IPessoaFisicaComplementoService
    {
        public PessoaFisicaComplementoService(IPessoaFisicaComplementoRepository repository)
            : base(repository)
        {
        }
    }
}
