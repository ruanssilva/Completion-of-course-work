
using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System.Collections.Generic;

namespace LVSA.Housing.Domain
{
    public class Condominio : AuditoriaComAtivo, IFilialContexto
    {
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Bloco> Blocos { get; set; }
        public virtual ICollection<Sindico> Sindicos { get; set; }
    }
}
