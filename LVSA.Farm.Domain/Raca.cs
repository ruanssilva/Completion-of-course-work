using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LVSA.Farm.Domain
{
    public class Raca : AuditoriaComExclusaoLogicaComAtivo, IFilialContexto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
        public int TipoAnimalId { get; set; }
        public virtual TipoAnimal TipoAnimal { get; set; }
        public virtual ICollection<Retrato> RetratoSet { get; set; }
    }
}
