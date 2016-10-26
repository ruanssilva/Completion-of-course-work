using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Global.Domain
{
    public class Pessoa : AuditoriaComExclusaoLogica, IColigadaContexto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Logradouro { get; set; }
        public int? NumeroResidencial { get; set; }
        public string Complemento { get; set; }
        public int? BairroId { get; set; }
        public virtual Bairro Bairro { get; set; }
        public int? CidadeId { get; set; }
        public virtual Cidade Cidade { get; set; }
        public short ColigadaId { get; set; }
    }
}
