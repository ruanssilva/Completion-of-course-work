using LVSA.Base.Domain.Services;
using LVSA.Housing.Domain.Interfaces.Repository;
using LVSA.Housing.Domain.Interfaces.Services;

namespace LVSA.Housing.Domain.Services
{
    public class MultaService : ServiceBase<Multa>, IMultaService
    {
        public MultaService(IMultaRepository multaRepository)
            : base(multaRepository)
        {

        }
    }
}
