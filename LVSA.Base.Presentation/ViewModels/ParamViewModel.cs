using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LVSA.Base.Presentation.ViewModels
{
    public class ParamViewModel
    {
        /// <summary>
        /// Valores do parâmetro
        /// </summary>
        public string[] Values { get; set; }
        /// <summary>
        /// Valor do parâmetro
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Identificador do parâmetro
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Máscara
        /// </summary>
        public string Mascara { get; set; }
        /// <summary>
        /// Coleção do source de T-SQL
        /// </summary>
        public IEnumerable<dynamic> Collection { get; set; }
        /// <summary>
        /// Multivalorável
        /// </summary>
        public bool Multi { get; set; }
        /// <summary>
        /// Código T-SQL ativo
        /// </summary>
        public bool TSQLAtivo { get; set; }
        /// <summary>
        /// Obrigatório
        /// </summary>
        public bool Obrigatorio { get; set; }
        /// <summary>
        /// Nome de exibição
        /// </summary>
        public string Exibicao { get; set; }
    }
}