using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LVSA.Farm.Domain
{
    public class Dosagem : AuditoriaComExclusaoLogicaComAtivo, IFilialContexto
    {
        public long Id { get; set; }
        public int MedicamentoId { get; set; }
        public long TratamentoId { get; set; }
        public decimal Quantidade { get; set; }
        public int Intervalo { get; set; }
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
        public virtual Medicamento Medicamento { get; set; }
        public virtual Tratamento Tratamento { get; set; }
    }
}
