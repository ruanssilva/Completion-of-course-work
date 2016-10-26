using LVSA.Base.Domain.Services;
using LVSA.Housing.Domain.Interfaces.Repository;
using LVSA.Housing.Domain.Interfaces.Services;

namespace LVSA.Housing.Domain.Services
{
    public class ReuniaoService : ServiceBase<Reuniao>, IReuniaoService
    {
        public ReuniaoService(IReuniaoRepository reuniaoRepository)
            : base(reuniaoRepository)
        {

        }
    }
}
