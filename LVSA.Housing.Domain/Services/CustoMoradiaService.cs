using LVSA.Base.Domain.Services;
using LVSA.Housing.Domain.Interfaces.Repository;
using LVSA.Housing.Domain.Interfaces.Services;

namespace LVSA.Housing.Domain.Services
{
    public class CustoMoradiaService : ServiceBase<CustoMoradia>, ICustoMoradiaService
    {
        public CustoMoradiaService(ICustoMoradiaRepository custoMoradiaRepository)
            : base(custoMoradiaRepository)
        {

        }
    }
}
