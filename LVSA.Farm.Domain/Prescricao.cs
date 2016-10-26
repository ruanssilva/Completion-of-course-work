using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Domain
{
    public class Prescricao : AuditoriaComExclusaoLogica, IFilialContexto
    {
        public long Id { get; set; }
        public long AnimalId { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
        public long? DiagnosticoId { get; set; }
        public long TratamentoId { get; set; }
        public virtual Animal Animal { get; set; }
        public virtual Diagnostico Diagnostico { get; set; }
        public virtual Tratamento Tratamento { get; set; }
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
    }
}
