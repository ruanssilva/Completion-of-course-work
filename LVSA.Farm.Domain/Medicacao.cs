using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LVSA.Farm.Domain
{
    public class Medicacao : AuditoriaComExclusaoLogicaComAtivo, IFilialContexto
    {
        public long Id { get; set; }
        public int MedicamentoId { get; set; }
        public long AnimalId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHorario { get; set; }
        public int? DoencaId { get; set; }
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
        public virtual Doenca Doenca { get; set; }
        public virtual Medicamento Medicamento { get; set; }        
    }
}
