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
    public class CategoriaInstrucaoAppService : AppServiceBase<CategoriaInstrucaoViewModel, CategoriaInstrucao, ICategoriaInstrucaoService>, ICategoriaInstrucaoAppService
    {
        public CategoriaInstrucaoAppService(ICategoriaInstrucaoService categoriaInstrucaoService)
            : base(categoriaInstrucaoService)
        {

        }

        public override IEnumerable<CategoriaInstrucaoViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public CategoriaInstrucaoViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }
    }
}
