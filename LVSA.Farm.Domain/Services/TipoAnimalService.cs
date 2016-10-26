﻿using LVSA.Base.Domain.Services;
using LVSA.Farm.Domain.Interfaces.Repository;
using LVSA.Farm.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Domain.Services
{
    public class TipoAnimalService : ServiceBase<TipoAnimal>, ITipoAnimalService
    {
        public TipoAnimalService(ITipoAnimalRepository tipoAnimalRepository)
            : base(tipoAnimalRepository)
        {

        }
    }
}
