using LVSA.Base.Domain.Services;
using LVSA.Housing.Domain.Interfaces.Repository;
using LVSA.Housing.Domain.Interfaces.Services;

namespace LVSA.Housing.Domain.Services
{
    public class MoradiaService : ServiceBase<Moradia>, IMoradiaService
    {
        public MoradiaService(IMoradiaRepository moradiaService)
            : base(moradiaService)
        {

        }
    }
}
