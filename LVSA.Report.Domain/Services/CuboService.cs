using LVSA.Base.Domain.Services;
using LVSA.Report.Domain.Interfaces.Repository;
using LVSA.Report.Domain.Interfaces.Services;

namespace LVSA.Report.Domain.Services
{
    public class CuboService : ServiceBase<Cubo>, ICuboService
    {
        public CuboService(ICuboRepository cuboRepository)
            : base(cuboRepository)
        {

        }
    }
}
