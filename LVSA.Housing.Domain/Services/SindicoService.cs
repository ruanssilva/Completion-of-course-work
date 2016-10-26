using LVSA.Base.Domain.Services;
using LVSA.Housing.Domain.Interfaces.Repository;
using LVSA.Housing.Domain.Interfaces.Services;

namespace LVSA.Housing.Domain.Services
{
    public class SindicoService : ServiceBase<Sindico>, ISindicoService
    {
        public SindicoService(ISindicoRepository sindicoRepository)
            : base(sindicoRepository)
        {

        }
    }
}
