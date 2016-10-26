using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain;

namespace LVSA.Noticia.Domain
{
    /// <summary>
    /// Modelo correspondente a união de Imagem(s) a uma Noticia
    /// </summary>
    public class NoticiaImagem : Auditoria
    {
        /// <summary>
        /// Chave do modelo vinculada ao modelo Noticia
        /// </summary>
        public long NoticiaId { get; set; }
        /// <summary>
        /// Chave do modelo vinculada ao modelo Imagem
        /// </summary>
        public long ImagemId { get; set; }
        /// <summary>
        /// Objeto virtual de navegabilidade para o modelo Noticia
        /// </summary>
        public virtual Noticia Noticia { get; set; }
        /// <summary>
        /// Objeto virtual de navegabilidade para o modelo Imagem
        /// </summary>
        public virtual Imagem Imagem { get; set; }
    }
}
