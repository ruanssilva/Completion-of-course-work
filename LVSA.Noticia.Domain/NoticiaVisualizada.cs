using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain;

namespace LVSA.Noticia.Domain
{
    /// <summary>
    /// Modelo correspondente a visualização de Noticia pelo Usuario
    /// </summary>
    public class NoticiaVisualizada :  Auditoria
    {
        /// <summary>
        /// Chave do modelo vinculada ao modelo Noticia
        /// </summary>
        public long NoticiaId { get; set; }
        /// <summary>
        /// Chave do modelo vinculada ao modelo Usuario
        /// </summary>
        public long UsuarioId { get; set; }
        /// <summary>
        /// Objeto virtual de navegabilidade do modelo Noticia
        /// </summary>
        public virtual Noticia Noticia { get; set; }
    }
}
