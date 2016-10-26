using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Domain
{
    public class Tratamento : AuditoriaComExclusaoLogicaComAtivo, IColigadaContexto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int? DoencaId { get; set; }
        public string Descricao { get; set; }
        public int Dias { get; set; }
        public virtual Doenca Doenca { get; set; }
        public short ColigadaId { get; set; }
        public virtual ICollection<Dosagem> DosagemSet { get; set; }
    }
}
