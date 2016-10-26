using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain;

namespace LVSA.Security.Domain
{
    /// <summary>
    /// Modelo que corresponde a dependência de recursos de uma aplicação a outra
    /// </summary>
    public class AplicacaoDependencia : Auditoria
    {
        /// <summary>
        /// Chave estrangeira com o modelo Aplicacao. #Os recursos deste esta no principal
        /// </summary>
        public int AplicacaoId { get; set; }
        /// <summary>
        /// Chave estrangeira com o modelo Aplicacao.  #Este depende dos recursos dos outros
        /// </summary>
        public int AplicacaoDependenteId { get; set; }
        /// <summary>
        /// Objeto de navegabilidade com o modelo Aplicacao. #Os recursos deste esta no principal
        /// </summary>
        public virtual Aplicacao Aplicacao { get; set; }
        /// <summary>
        /// Objeto de navegabilidade com o modelo Aplicacao.  #Este depende dos recursos dos outros
        /// </summary>
        public virtual Aplicacao AplicacaoDependente { get; set; }
    }
}
