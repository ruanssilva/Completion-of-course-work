using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Domain
{
    public class Terreno : Auditoria, IFilialContexto
    {
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal? M2 { get; set; }
        public decimal? Largura { get; set; }
        public decimal? Comprimento { get; set; }

        public virtual ICollection<Pasto> PastoSet { get; set; }
        public virtual ICollection<Retrato> RetratoSet { get; set; }
    }
}
