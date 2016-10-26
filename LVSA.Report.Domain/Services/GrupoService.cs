﻿using LVSA.Base.Domain.Services;
using LVSA.Report.Domain.Interfaces.Repository;
using LVSA.Report.Domain.Interfaces.Services;

namespace LVSA.Report.Domain.Services
{
    public class GrupoService : ServiceBase<Grupo>, IGrupoService
    {
        public GrupoService(IGrupoRepository grupoRepository)
            : base(grupoRepository)
        {

        }
    }
}
