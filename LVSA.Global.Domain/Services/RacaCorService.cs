using LVSA.Base.Domain.Services;
using LVSA.Global.Domain.Interfaces.Repository;
using LVSA.Global.Domain.Interfaces.Services;

namespace LVSA.Global.Domain.Services
{
    public class RacaCorService : ServiceBase<RacaCor>, IRacaCorService
    {
        public RacaCorService(IRacaCorRepository repository)
            : base(repository)
        {

        }
    }
}
