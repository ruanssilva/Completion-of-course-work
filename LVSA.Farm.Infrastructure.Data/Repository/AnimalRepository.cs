﻿using LVSA.Base.Infrastructure.Data.Repository.EF;
using LVSA.Farm.Domain;
using LVSA.Farm.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Infrastructure.Data.Repository
{
    public class AnimalRepository : RepositoryBase<Animal>, IAnimalRepository
    {
    }
}
