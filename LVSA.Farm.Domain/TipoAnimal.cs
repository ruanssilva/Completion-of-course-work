using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LVSA.Farm.Domain
{
    public class TipoAnimal : AuditoriaComExclusaoLogicaComAtivo, IColigadaContexto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public short ColigadaId { get; set; }
        public virtual ICollection<Raca> RacaSet { get; set; }
        public virtual ICollection<Retrato> RetratoSet { get; set; }
    }
}
