using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Domain
{
    public class LocalPesagem : AuditoriaComExclusaoLogicaComAtivo, IColigadaContexto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
    }
}
