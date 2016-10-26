using LVSA.Base.Domain.Services;
using LVSA.Housing.Domain.Interfaces.Repository;
using LVSA.Housing.Domain.Interfaces.Services;

namespace LVSA.Housing.Domain.Services
{
    public class MoradorService : ServiceBase<Morador>, IMoradorService
    {
        public MoradorService(IMoradorRepository moradorRepository)
            : base(moradorRepository)
        {

        }
    }
}
