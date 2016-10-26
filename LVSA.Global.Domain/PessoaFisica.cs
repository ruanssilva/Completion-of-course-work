using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Global.Domain
{
    public class PessoaFisica : Pessoa
    {
        public DateTime? DataNascimento { get; set; }
        public bool? Masculino { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public virtual PessoaFisicaComplemento PessoaComplemento { get; set; }
        
    }
}
