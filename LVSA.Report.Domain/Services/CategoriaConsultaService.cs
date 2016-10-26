using LVSA.Report.Domain.Interfaces.Repository;
using LVSA.Report.Domain.Interfaces.Services;
using LVSA.Base.Domain.Services;

namespace LVSA.Report.Domain.Services
{
    public class CategoriaConsultaService: ServiceBase<CategoriaConsulta>, ICategoriaConsultaService
    {
        public CategoriaConsultaService(ICategoriaConsultaRepository categoriaConsultaRepository)
            : base(categoriaConsultaRepository)
        {
        }
    }
}
