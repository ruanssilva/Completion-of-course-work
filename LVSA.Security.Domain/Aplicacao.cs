using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain;

namespace LVSA.Security.Domain
{
    /// <summary>
    /// Modelo que corresponde a uma aplicação ou um conjunto de funcionalidades agrupadas
    /// </summary>
    public class Aplicacao : AuditoriaComAtivo
    {
        /// <summary>
        /// Chave auto-incremento do modelo
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Sigla correspondente para aplicação/conjunto de funcionalidades
        /// </summary>
        public string Sigla { get; set; }
        /// <summary>
        /// Nome da aplicação
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Nome de exibição da aplicação
        /// </summary>
        public string Exibicao { get; set; }
        /// <summary>
        /// Descrição breve da aplicação
        /// </summary>
        public string Descricao { get; set; }
        /// <summary>
        /// Link de acesso da aplicação
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// Icone no formato da fonte Awesome Ex:. <i href='fa fa-code' />
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// Valor de uma imagem carregada para logo da aplicação
        /// </summary>
        public byte[] Logo { get; set; }
        /// <summary>
        /// Content-Type da imagem de logo carregada para aplicação
        /// </summary>
        public string ContentType { get; set; }
        public bool Abstrata { get; set; }
        public bool Desktop { get; set; }
        public bool Blank { get; set; }

        public ICollection<Recurso> RecursoSet { get; set; }
        public virtual ICollection<Grupo> GrupoSet { get; set; }
        public virtual ICollection<Parametrizacao> ParametrizacaoSet { get; set; }
        public virtual ICollection<AplicacaoDependencia> AplicacaoDependenciaSet { get; set; }
        public virtual ICollection<AplicacaoDependencia> AplicacaoDependenteSet { get; set; }
    }
}
