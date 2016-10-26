using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Base.Domain.Interfaces.Domain
{
    public interface IFilialContexto : IColigadaContexto
    {
        short FilialId { get; set; }
    }
}
