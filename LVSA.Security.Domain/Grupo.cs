using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain.Interfaces.Domain;
using LVSA.Base.Domain;

namespace LVSA.Security.Domain
{
    /// <summary>
    /// Modelo correspondente ao grupo que receberá permissões aos recursos das aplicações
    /// </summary>
    public class Grupo : AuditoriaComExclusaoLogicaComAtivo, IOpcionalContexto
    {
        /// <summary>
        /// Chave auto-incremento do modelo
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Nome do grupo
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Descrição breve do grupo
        /// </summary>
        public string Descricao { get; set; }
        public string Tags { get; set; }
        /// <summary>
        /// Chave estrangeira para o modelo Aplicacao
        /// </summary>
        public int? AplicacaoId { get; set; }
        /// <summary>
        /// Campo para filtro de informação. Para valor igual a 'null' corresponde que todas coligadas terão acesso a informação
        /// </summary>
        public short? ColigadaId { get; set; }
        /// <summary>
        /// Campo para filtro de informação. Para valor igual a 'null' corresponde que todas filiais terão acesso a informação
        /// </summary>
        public short? FilialId { get; set; }
        /// <summary>
        /// Campo destinado a definição de que todos usuários pertencem a este grupo automaticamente quando se tem acesso ao determinado contexto
        /// </summary>
        public bool? Publico { get; set; }

        /// <summary>
        /// Objeto virtual de navegação para os modelos de Agrupamento relacionados ao Grupo
        /// </summary>
        public virtual ICollection<Agrupamento> AgrupamentoSet { get; set; }
        /// <summary>
        /// Objeto virtual de navegação para permissões do grupo
        /// </summary>
        public virtual ICollection<Permissao> PermissaoSet { get; set; }
        /// <summary>
        /// Objeto virtual de navegação para a aplicação do grupo. Para valor igual a 'null' corresponde que todas aplicações terão acesso a informação
        /// </summary>
        public virtual Aplicacao Aplicacao { get; set; }
    }
}
