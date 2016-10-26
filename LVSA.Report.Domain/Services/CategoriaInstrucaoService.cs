using LVSA.Base.Domain.Services;
using LVSA.Report.Domain.Interfaces.Repository;
using LVSA.Report.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Domain.Services
{
    public class CategoriaInstrucaoService : ServiceBase<CategoriaInstrucao>, ICategoriaInstrucaoService
    {
        public CategoriaInstrucaoService(ICategoriaInstrucaoRepository categoriaInstrucaoRepository)
            : base(categoriaInstrucaoRepository)
        {

        }
    }
}
