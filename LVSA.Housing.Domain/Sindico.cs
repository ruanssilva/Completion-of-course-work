using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System.Collections.Generic;

namespace LVSA.Housing.Domain
{
    public class Sindico : AuditoriaComExclusaoLogicaComAtivo, IFilialContexto
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
        public virtual ICollection<Bloco> Blocos { get; set; }
        public virtual Condominio Condominio { get; set; }
    }
}
