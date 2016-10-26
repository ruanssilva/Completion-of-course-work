using LVSA.Base.Domain.Services;
using LVSA.Housing.Domain.Interfaces.Repository;
using LVSA.Housing.Domain.Interfaces.Services;

namespace LVSA.Housing.Domain.Services
{
    public class CondominioService : ServiceBase<Condominio>, ICondominioService
    {
        public CondominioService(ICondominioRepository condominioRepository)
            : base(condominioRepository)
        {

        }
    }
}
