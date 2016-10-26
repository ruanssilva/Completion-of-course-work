using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain;

namespace LVSA.Security.Domain
{
    /// <summary>
    /// Modelo correspondente a permissão de um Grupo/Usuario
    /// </summary>
    public class Permissao :  AuditoriaComExclusaoLogica
    {
        /// <summary>
        /// Chave do modelo auto-increment
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Chave estrangeira vinculada ao Recurso
        /// </summary>
        public long? RecursoId { get; set; }
        public long? RelatorioId { get; set; }
        /// <summary>
        /// Chave estrangeira viculada ao Grupo
        /// </summary>
        public long? GrupoId { get; set; }
        /// <summary>
        /// Chave estrangeira vinculada ao Usuario
        /// </summary>
        public long? UsuarioId { get; set; }
        /// <summary>
        /// Objeto virtual de navegabilidade para Recurso
        /// </summary>
        public virtual Recurso Recurso { get; set; }
        /// <summary>
        /// Objeto virtual de navegabilidaed para Grupo
        /// </summary>
        public virtual Grupo Grupo { get; set; }
        /// <summary>
        /// Objeto virtual de navegabilidade para Usuario
        /// </summary>
        public virtual Usuario Usuario { get; set; }

        public bool? Read { get; set; }
        public bool? Write { get; set; }
        public bool? Rewrite { get; set; }
        public bool? Delete { get; set; }
    }
}
