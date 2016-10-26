using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Domain
{
    public class Dose : Auditoria, IFilialContexto
    {
        public long Id { get; set; }
        public long AnimalId { get; set; }
        public long DosagemId { get; set; }
        public DateTime Data { get; set; }
        public decimal Quantidade { get; set; }
        public string Observacao { get; set; }
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
        public virtual Animal Animal { get; set; }
        public virtual Dosagem Dosagem { get; set; }
    }
}
