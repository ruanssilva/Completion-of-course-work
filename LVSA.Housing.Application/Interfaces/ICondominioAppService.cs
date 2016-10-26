﻿using LVSA.Housing.Application.ViewModels;
using LVSA.Housing.Domain;

namespace LVSA.Housing.Application.Interfaces
{
    public interface ICondominioAppService : IAppServiceBase<CondominioViewModel,Condominio>
    {
        CondominioViewModel Obter();
    }
}
