using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain.Interfaces.Domain;
using LVSA.Base.Domain;

namespace LVSA.Noticia.Domain
{
    /// <summary>
    /// Modelo correspondente a noticias/informativos
    /// </summary>
    public class Noticia : AuditoriaComExclusaoLogicaComAtivo
    {
        /// <summary>
        /// Chave do modelo auto-incremento
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Titulo da notícia/informativo
        /// </summary>
        public string Titulo { get; set; }
        /// <summary>
        /// Subtitulo da notícia/informativo
        /// </summary>
        public string Subtitulo { get; set; }
        /// <summary>
        /// Texto da notícia/informativo
        /// </summary>
        public string Texto { get; set; }
        /// <summary>
        /// Autor da notícia/informativo
        /// </summary>
        public string Autor { get; set; }
        /// <summary>
        /// Data de publicação da notícia/informativo, quando ela começará a ser exibida
        /// </summary>
        public DateTime PublicadoEm { get; set; }
        /// <summary>
        /// Data de expiração da notícia/informativo, quando ela deixará de ser exibida
        /// </summary>
        public DateTime ExpiraEm { get; set; }
        public string Tags { get; set; }
        /// <summary>
        /// Objeto virtual de navegabilidade para as NoticiaImagem do modelo
        /// </summary>
        public virtual ICollection<NoticiaImagem> NoticiaImagemSet { get; set; }
        /// <summary>
        /// Objeto virtual de navegabilidade para as NoticiaVisualizada do modelo
        /// </summary>
        public virtual ICollection<NoticiaVisualizada> NoticiaVisualizadaSet { get; set; }
    }
}
