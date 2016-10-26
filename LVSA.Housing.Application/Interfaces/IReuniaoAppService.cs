using LVSA.Housing.Application.ViewModels;
using LVSA.Housing.Domain;
using System.Collections.Generic;

namespace LVSA.Housing.Application.Interfaces
{
    public interface IReuniaoAppService : IAppServiceBase<ReuniaoViewModel,Reuniao>
    {
        void Presenca(ReuniaoViewModel model);
        void Ata(ReuniaoViewModel model);
        IEnumerable<ReuniaoViewModel> Reunioes();
    }
}
