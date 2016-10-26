using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Domain;
using LVSA.Security.Domain.Interfaces.Repository;

namespace LVSA.Security.Infrastructure.Data.Repository.EF
{
    public class ParametroRepository : RepositoryBase<Parametro>, IParametroRepository
    {
    }
}
