﻿using LVSA.Global.Application.Interfaces;
using LVSA.Global.Application.ViewModels;
using LVSA.Global.Domain;
using LVSA.Global.Domain.Interfaces.Services;

namespace LVSA.Global.Application
{
    public class EstadoAppService : AppServiceBase<EstadoViewModel, Estado, IEstadoService>, IEstadoAppService
    {
        public EstadoAppService(IEstadoService estadoService)
            : base(estadoService)
        {

        }

        public override System.Collections.Generic.IEnumerable<EstadoViewModel> Todos()
        {
            return Filtrar(f => true);
        }
    }
}
