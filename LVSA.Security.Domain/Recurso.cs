using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain;

namespace LVSA.Security.Domain
{
    /// <summary>
    /// Modelo correspondente a um recurso da Aplicacao
    /// </summary>
    public class Recurso : AuditoriaComExclusaoLogicaComAtivo
    {
        /// <summary>
        /// Chave do modelo auto-increment
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Chave estrangeira vinculada a Aplicacao
        /// </summary>
        public int AplicacaoId { get; set; }
        /// <summary>
        /// Chave estrangeira vinculada ao TipoRecurso
        /// </summary>
        public short TipoRecursoId { get; set; }
        /// <summary>
        /// Nome do recurso
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Nome de exibição do recurso
        /// </summary>
        public string Exibicao { get; set; }
        /// <summary>
        /// Controller onde a action do recurso está localizada
        /// </summary>
        public string Controller { get; set; }
        /// <summary>
        /// Action do recurso
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// Icone no formato da fonte Awesome Ex:. <i href='fa fa-code' />
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// Descrição breve do recurso
        /// </summary>
        public string Descricao { get; set; }
        /// <summary>
        /// Tags do recurso, para serem vinculadas na pesquisa do usuário
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// Peso da ordenação do recurso
        /// </summary>
        public decimal? Peso { get; set; }
        /// <summary>
        /// Objeto de navegabilidade para TipoRecurso
        /// </summary>
        public long? RecursoPaiId { get; set; }
        public virtual ICollection<Recurso> RecursoSet { get; set; }

        public virtual Recurso RecursoPai { get; set; }

        public virtual TipoRecurso TipoRecurso { get; set; }
        /// <summary>
        /// Objeto de navegabilidade para Aplicacao
        /// </summary>
        public virtual Aplicacao Aplicacao { get; set; }
    }
}
