using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain;

namespace LVSA.Security.Domain
{
    /// <summary>
    /// Modelo correspondente para o definição de Parametros a Aplicação
    /// </summary>
    public class Parametrizacao : Auditoria
    {
        /// <summary>
        /// Chave do modelo, correspondente ao valor que o desenvolvedor pegará na sua aplicação
        /// </summary>
        public string Codigo { get; set; }
        /// <summary>
        /// Chave do modelo vinculado a Aplicacao
        /// </summary>
        public int AplicacaoId { get; set; }
        /// <summary>
        /// Chave do modelo vinculado ao Parametro
        /// </summary>
        public int ParametroId { get; set; }
        /// <summary>
        /// Nome de exibição do parametro ao usuário
        /// </summary>
        public string Exibicao { get; set; }
        /// <summary>
        /// Campo para quando o parâmetro for obrigatório
        /// </summary>
        public bool Obrigatorio { get; set; }
        /// <summary>
        /// Campo para quando o parâmetro aceita mais de um valores
        /// </summary>
        public bool Multi { get; set; }
        public short Sequencia { get; set; }
        /// <summary>
        /// Objeto virtual de navegabilidade para Aplicacao
        /// </summary>
        public virtual Aplicacao Aplicacao { get; set; }
        /// <summary>
        /// Objeto virtual de navegabilidade para Parametro
        /// </summary>
        public virtual Parametro Parametro { get; set; }
    }
}
