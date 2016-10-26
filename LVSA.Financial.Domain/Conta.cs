using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Financial.Domain
{
    public class Conta : AuditoriaComExclusaoLogicaComAtivo, IFilialContexto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public short TipoContaId { get; set; }
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
        public virtual TipoConta TipoConta { get; set; }
        public virtual ICollection<CCusto> CCustoSet { get; set; }
    }
}
