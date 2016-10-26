using LVSA.Base.Domain.Services;
using LVSA.Housing.Domain.Interfaces.Repository;
using LVSA.Housing.Domain.Interfaces.Services;

namespace LVSA.Housing.Domain.Services
{
    public class AvisoService : ServiceBase<Aviso>, IAvisoService
    {
        public AvisoService(IAvisoRepository avisoRepository)
            : base(avisoRepository)
        {

        }
    }
}
