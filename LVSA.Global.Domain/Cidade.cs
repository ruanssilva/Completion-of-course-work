using LVSA.Base.Domain;
using System.Collections.Generic;

namespace LVSA.Global.Domain
{
    public class Cidade : Auditoria
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public int EstadoId { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual ICollection<Bairro> Bairros { get; set; }
        public virtual ICollection<PessoaFisica> PessoasFisica { get; set; }
        public virtual ICollection<PessoaJuridica> PessoasJuridica { get; set; }
        public virtual ICollection<PessoaFisicaComplemento> PessoasFisicaComplemento { get; set; }
    }
}
