using LVSA.Base.Domain.Services;
using LVSA.Housing.Domain.Interfaces.Repository;
using LVSA.Housing.Domain.Interfaces.Services;

namespace LVSA.Housing.Domain.Services
{
    public class MultaMoradorService : ServiceBase<MultaMorador>, IMultaMoradorService
    {
        public MultaMoradorService(IMultaMoradorRepository multaMoradorRepository)
            : base(multaMoradorRepository)
        {

        }
    }
}
