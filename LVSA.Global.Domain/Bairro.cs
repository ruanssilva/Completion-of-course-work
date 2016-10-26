using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Global.Domain
{
    public class Bairro : Auditoria, IColigadaContexto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CidadeId { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual ICollection<PessoaFisica> PessoasFisica { get; set; }
        public virtual ICollection<PessoaJuridica> PessoasJuridica { get; set; }
        public short ColigadaId { get; set; }
     
    }
}
