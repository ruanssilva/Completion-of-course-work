using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain;

namespace LVSA.Security.Domain
{
    /// <summary>
    /// Modelo correspondente a um parametro
    /// </summary>
    public class Parametro : AuditoriaComAtivo
    {
        /// <summary>
        /// Chave do modelo auto-incremento
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome do parametro
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Descrição breve do parametro
        /// </summary>
        public string Descricao { get; set; }
        public string Type { get; set; }
        /// <summary>
        /// Instrução TSQL para o source do parâmetro
        /// </summary>
        public string TSQL { get; set; }
        /// <summary>
        /// Máscara do campo para o usuário, Ex.: Para parâmetros como data 99/99/9999
        /// </summary>
        public string Mascara { get; set; }
        /// <summary>
        /// Regex para validação do valor digitado pelo usuário
        /// </summary>
        public string Regex { get; set; }
        /// <summary>
        /// Caso a TSQL do parâmetro esteja ativa para pré-processamento de dados ao usuário
        /// </summary>
        public bool TSQLAtivo { get; set; }
    }
}
