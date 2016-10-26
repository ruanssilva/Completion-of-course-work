using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain;

namespace LVSA.Noticia.Domain
{
    /// <summary>
    /// Modelo de imagens vinculadas ao dominío
    /// </summary>
    public class Imagem : Auditoria
    {
        /// <summary>
        /// Chave auto-incremento do modelo
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Valor em binário da imagem no modelo
        /// </summary>
        public byte[] Valor { get; set; }
        /// <summary>
        /// Content-Type da imagem salva no modelo
        /// </summary>
        public string ContentType { get; set; }
    }
}
