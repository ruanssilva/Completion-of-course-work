using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Domain
{
    public class Pasto : AuditoriaComExclusaoLogicaComAtivo, IFilialContexto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
        public decimal? M2 { get; set; }
        public decimal? Largura { get; set; }
        public decimal? Comprimento { get; set; }        
        public virtual Terreno Terreno { get; set; }
        public virtual ICollection<Retrato> RetratoSet { get; set; }
        public virtual ICollection<Piquete> PiqueteSet { get; set; }
    }
}
