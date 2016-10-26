using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain;

namespace LVSA.Security.Domain
{
    /// <summary>
    /// Modelo correspondente a tipo de recurso 
    /// </summary>
    public class TipoRecurso : AuditoriaComAtivo
    {
        /// <summary>
        /// Chave do modelo auto-increment
        /// </summary>
        public short Id { get; set; }
        /// <summary>
        /// Campo de indentificação do tipo do recurso
        /// </summary>
        public string Codigo { get; set; }
        /// <summary>
        /// Nome do tipo de recurso
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Descrição breve do tipo recurso
        /// </summary>
        public string Descricao { get; set; }
    }
}
