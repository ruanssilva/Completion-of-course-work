using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Application.ComponentModel.DataAnnotations;

namespace LVSA.Noticia.Application.ViewModels
{
    public class NoticiaViewModel
    {
        /// <summary>
        /// Chave do modelo auto-incremento
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Titulo da notícia/informativo
        /// </summary>
        [DisplayName("Título")]
        [ComprimentoMaximo(65)]
        public string Titulo { get; set; }
        /// <summary>
        /// Subtitulo da notícia/informativo
        /// </summary>
        [DisplayName("Subtítulo")]
        [ComprimentoMaximo(65)]
        public string Subtitulo { get; set; }
        /// <summary>
        /// Texto da notícia/informativo
        /// </summary>
        [DisplayName("Texto")]
        public string Texto { get; set; }
        /// <summary>
        /// Autor da notícia/informativo
        /// </summary>
        [DisplayName("Autor")]
        [ComprimentoMaximo(65)]
        public string Autor { get; set; }
        /// <summary>
        /// Data de publicação da notícia/informativo, quando ela começará a ser exibida
        /// </summary>
        [DisplayName("Publicar em")]
        public DateTime PublicadoEm { get; set; }
        /// <summary>
        /// Data de expiração da notícia/informativo, quando ela deixará de ser exibida
        /// </summary>
        [DisplayName("Expirar em")]
        public DateTime ExpiraEm { get; set; }
        [DisplayName("Tags")]
        [ComprimentoMaximo(65)]
        public string Tags { get; set; }
        [DisplayName("Ativo")]
        public bool Ativo { get; set; }
        [DisplayName("Aplicações")]
        public int[] AplicacaoIdSet { get; set; }
        public long[] UsuarioIdSet { get; set; }
        public short[] FilialIdSet { get; set; }

        public IEnumerable<ImagemViewModel> ImagemSet { get; set; }
    }
}
