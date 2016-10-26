using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Global.Domain
{
    public class PessoaFisicaComplemento : Auditoria, IColigadaContexto
    {
        public int PessoaId { get; set; }
        public virtual PessoaFisica Pessoa { get; set; }
        public long? UsuarioId { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string GooglePlus { get; set; }
        public int? RacaCorId { get; set; }
        public virtual RacaCor RacaCor { get; set; }
        public short ColigadaId { get; set; }
        public int? CidadeNaturalidadeId { get; set; }
        public virtual Cidade CidadeNaturalidade { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set;}
        public string Email { get; set; }
        public int? EscolaridadeId { get; set; }
        public virtual Escolaridade Escolaridade { get; set; }
        public int? TitulacaoId { get; set; }
        public virtual Titulacao Titulacao { get; set; }
        public int? ImagemId { get; set; }
        public virtual Imagem Imagem { get; set; }
    }
}
