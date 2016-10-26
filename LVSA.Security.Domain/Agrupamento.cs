using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain;

namespace LVSA.Security.Domain
{
    /// <summary>
    /// Modelo de agrupamento de usuários aos grupos
    /// </summary>
    public class Agrupamento : Auditoria
    {
        /// <summary>
        /// Chave estrangeira do modelo para Usuario
        /// </summary>
        public long UsuarioId { get; set; }
        /// <summary>
        /// Chave estrangeira do modeo para Grupo
        /// </summary>
        public long GrupoId { get; set; }
        /// <summary>
        /// Objeto virtual de navegação para o modelo Usuario
        /// </summary>
        public virtual Usuario Usuario { get; set; }
        /// <summary>
        /// Objeto virtual de navegação para o modelo Grupo
        /// </summary>
        public virtual Grupo Grupo { get; set; }
    }
}
