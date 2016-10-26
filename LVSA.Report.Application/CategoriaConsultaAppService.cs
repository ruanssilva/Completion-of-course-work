using LVSA.Report.Application.Interfaces;
using LVSA.Report.Application.ViewModels;
using LVSA.Report.Domain;
using LVSA.Report.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Application
{
    public class CategoriaConsultaAppService : AppServiceBase<CategoriaConsultaViewModel, CategoriaConsulta, ICategoriaConsultaService>, ICategoriaConsultaAppService
    {
        public CategoriaConsultaAppService(ICategoriaConsultaService categoriaConsultaService)
            : base(categoriaConsultaService)
        {

        }

        public override IEnumerable<CategoriaConsultaViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public CategoriaConsultaViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }
    }
}
