using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain;

namespace LVSA.Security.Domain
{
    /// <summary>
    /// Modelo correspondente a um usuário da aplicação
    /// </summary>
    public class Usuario : Auditoria
    {
        /// <summary>
        /// Chave do modelo auto-increment
        /// </summary>
        public long Id { get; set; }
        public string Codigo { get; set; }
        /// <summary>
        /// Chave estrangeira para o modelo TipoUsuario
        /// </summary>
        public short? TipoUsuarioId { get; set; }
        /// <summary>
        /// Campo do Nome do usuário
        /// </summary>
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }

        public bool Bloqueado { get; set; }
        public byte[] Avatar { get; set; }

        /// <summary>
        /// Objeto virtual de navegabilidade para TipoUsuario
        /// </summary>
        public virtual TipoUsuario TipoUsuario { get; set; }
        /// <summary>
        /// Objeto virtual de navegabilidade para os Agrupamento do modelo
        /// </summary>
        public virtual ICollection<Agrupamento> AgrupamentoSet { get; set; }
        /// <summary>
        /// Objeto virtual de navegabilidade para as Permissao do modelo
        /// </summary>
        public virtual ICollection<Permissao> PermissaoSet { get; set; }
    }
}
