using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Housing.Domain
{
    public class Multa : AuditoriaComAtivo, IFilialContexto
    {
        public int Id { get; set; }
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
