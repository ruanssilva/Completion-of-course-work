using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain.Interfaces.Domain;
using LVSA.Base.Domain;

namespace LVSA.Security.Domain
{
    /// <summary>
    /// Modelo que corresponde o acesso das filiais as aplicações 
    /// </summary>
    public class AplicacaoAcesso : AuditoriaComAtivo, IOpcionalContexto
    {
        /// <summary>
        /// Chave auto-incremento do modelo
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Chave estrangeira do modelo para Aplicacao
        /// </summary>
        public int AplicacaoId { get; set; }
        /// <summary>
        /// Data de vencimento do acesso a aplicação. Para valor igual a 'null' não existe vencimento para o acesso
        /// </summary>
        public DateTime? Vencimento { get; set; }
        /// <summary>
        /// E-mail do gestor responsável ao acesso da aplicação
        /// </summary>
        public string EmailGestor { get; set; }
        /// <summary>
        /// Campo para filtro de informação. Para valor igual a 'null' corresponde que todas coligadas terão acesso a informação
        /// </summary>
        public short? ColigadaId { get; set; }
        /// <summary>
        /// Campo para filtro de informação. Para valor igual a 'null' corresponde que todas filiais terão acesso a informação
        /// </summary>
        public short? FilialId { get; set; }
        /// <summary>
        /// Campo de navegabilidade para o modelo Aplicacao
        /// </summary>
        public virtual Aplicacao Aplicacao { get; set; }
    }
}
