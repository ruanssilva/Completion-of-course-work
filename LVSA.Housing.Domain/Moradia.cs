
using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Housing.Domain
{
    public class Moradia : AuditoriaComExclusaoLogicaComAtivo, IFilialContexto
    {
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
        public int Id { get; set; }
        public int? BlocoId { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Morador> Moradores { get; set; }

        public virtual Condominio Condominio { get; set; }
        public virtual Bloco Bloco { get; set; }
    }
}
