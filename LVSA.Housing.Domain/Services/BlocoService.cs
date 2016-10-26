using LVSA.Base.Domain.Services;
using LVSA.Housing.Domain.Interfaces.Repository;
using LVSA.Housing.Domain.Interfaces.Services;

namespace LVSA.Housing.Domain.Services
{
    public class BlocoService : ServiceBase<Bloco>, IBlocoService
    {
        public BlocoService(IBlocoRepository blocoRepository)
            : base(blocoRepository)
        {

        }
    }
}
