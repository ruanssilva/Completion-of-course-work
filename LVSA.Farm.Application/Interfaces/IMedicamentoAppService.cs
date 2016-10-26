using LVSA.Farm.Application.ViewModels;
using LVSA.Farm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Application.Interfaces
{
    public interface IMedicamentoAppService : IAppServiceBase<MedicamentoViewModel,Medicamento>
    {  
    }
}
