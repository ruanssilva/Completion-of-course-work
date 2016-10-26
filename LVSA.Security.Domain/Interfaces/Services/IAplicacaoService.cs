using LVSA.Base.Domain.Interfaces.Services;

namespace LVSA.Security.Domain.Interfaces.Services
{
    public interface IAplicacaoService : IServiceBase<Aplicacao>
    {
        Aplicacao GetById(int id);
    }
}
