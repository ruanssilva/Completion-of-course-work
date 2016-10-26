
using LVSA.Base.Domain.Services;
using LVSA.Global.Domain.Interfaces.Repository;
using LVSA.Global.Domain.Interfaces.Services;
namespace LVSA.Global.Domain.Services
{
    public class BairroService : ServiceBase<Bairro>, IBairroService
    {
        public BairroService(IBairroRepository repository)
            : base(repository)
        {
            
        }
    }
}
