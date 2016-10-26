using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain;

namespace LVSA.Security.Domain
{
    /// <summary>
    /// Modelo correspondente a tipo de usuario
    /// </summary>
    public class TipoUsuario : AuditoriaComAtivo
    {
        /// <summary>
        /// Chave do modelo auto-increment
        /// </summary>
        public short Id { get; set; }
        /// <summary>
        /// Nome do tipo de usuario
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Campo de indentificação do tipo do usuário
        /// </summary>
        public string Codigo { get; set; }
        /// <summary>
        /// Descrição breve do tipo de usuário
        /// </summary>
        public string Descricao { get; set; }
    }
}
