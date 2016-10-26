using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Application.ComponentModel.DataAnnotations;

namespace LVSA.Security.Application.ViewModels
{
    public class ParametroViewModel
    {
        [Obrigatorio]
        public int Id { get; set; }
        [Obrigatorio]
        [ComprimentoMaximo(65)]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        [Obrigatorio]
        [ComprimentoMaximo(255)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        [Obrigatorio]
        [ComprimentoMaximo(65)]
        [DisplayName("Tipo")]
        public string Type { get; set; }
        [DisplayName("TSQL.")]
        public string TSQL { get; set; }
        [ComprimentoMaximo(65)]
        [DisplayName("Máscara")]
        public string Mascara { get; set; }
        [ComprimentoMaximo(65)]
        [DisplayName("Regex")]
        public string Regex { get; set; }
        [DisplayName("Ativo")]
        public bool Ativo { get; set; }
        [DisplayName("TSQL. Ativo")]
        public bool TSQLAtivo { get; set; }
        [Obrigatorio]
        [ComprimentoMaximo(65)]
        [DisplayName("Código")]
        public string Codigo { get; set; }
        [Obrigatorio]
        [ComprimentoMaximo(65)]
        [DisplayName("Exibição")]
        public string Exibicao { get; set; }
        [Obrigatorio]
        [DisplayName("Obrigatório")]
        public bool Obrigatorio { get; set; }
        [Obrigatorio]
        [DisplayName("Multivalorável")]
        public bool Multi { get; set; }
        [Obrigatorio]
        [DisplayName("Sequência")]
        public short Sequencia { get; set; }
        [DisplayName("Valor")]
        public string Value { get; set; }
    }
}
