using LVSA.Base.Domain;
using System.Collections.Generic;

namespace LVSA.Global.Domain
{
    public class Escolaridade : Auditoria
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public ICollection<PessoaFisicaComplemento> PessoasComplemento { get; set; }
    }
}
