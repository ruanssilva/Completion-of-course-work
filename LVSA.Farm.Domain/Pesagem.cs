using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Domain
{
    public class Pesagem : AuditoriaComExclusaoLogicaComAtivo, IFilialContexto
    {
        public long Id { get; set; }
        public long AnimalId { get; set; }
        public int LocalPesagemId { get; set; }
        public decimal? Peso { get; set; }
        public string Observacao { get; set; }
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
        public virtual Animal Animal { get; set; }
        public virtual LocalPesagem LogalPesagem { get; set; }
        public ICollection<Retrato> RetratoSet { get; set; }
    }
}
