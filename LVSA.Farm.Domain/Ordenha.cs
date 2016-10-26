using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Domain
{
    public class Ordenha : AuditoriaComExclusaoLogica, IFilialContexto
    {
        public long Id { get; set; }
        public DateTime Horario { get; set; }
        public long AnimalId { get; set; }
        public decimal Quantidade { get; set; }
        public string Observacao { get; set; }
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }

        public virtual Animal Animal { get; set; }
    }
}
