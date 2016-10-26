using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Domain
{
    public class Diagnostico : AuditoriaComExclusaoLogicaComAtivo, IFilialContexto
    {
        public long Id { get; set; }
        public long AnimalId { get; set; }
        public int? DoencaId { get; set; }
        public string Observacao { get; set; }
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
        public DateTime DataDiagnostico { get; set; }
        public virtual Animal Animal { get; set; }
        public virtual Doenca Doenca { get; set; }
        public virtual ICollection<Retrato> RetratoSet { get; set; }
        public virtual ICollection<Prescricao> PrescricaoSet { get; set; }
    }
}
