using LVSA.Base.Domain.Services;
using LVSA.Global.Domain.Interfaces.Repository;
using LVSA.Global.Domain.Interfaces.Services;

namespace LVSA.Global.Domain.Services
{
    public class CidadeService : ServiceBase<Cidade>, ICidadeService
    {
        public CidadeService(ICidadeRepository repository)
            : base(repository)
        {
        }
    }
}
