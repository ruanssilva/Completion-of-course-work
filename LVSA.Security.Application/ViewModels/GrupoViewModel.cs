using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Application.ComponentModel.DataAnnotations;

namespace LVSA.Security.Application.ViewModels
{
    public class GrupoViewModel
    {
        /// <summary>
        /// Chave única do grupo
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Nome do grupo
        /// </summary>
        [Obrigatorio]
        [ComprimentoMaximo(65)]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        /// <summary>
        /// Descrição do grupo
        /// </summary>
        [ComprimentoMaximo(255)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        /// <summary>
        /// Palavras chaves de marcação/identificação do grupo
        /// </summary>
        [ComprimentoMaximo(65)]
        [DisplayName("Tags")]
        public string Tags { get; set; }
        /// <summary>
        /// Status do grupo
        /// </summary>
        [DisplayName("Ativo")]
        public bool Ativo { get; set; }
        /// <summary>
        /// Chave de ligação a aplicação que o grupo pertence
        /// </summary>
        [DisplayName("Aplicação")]
        public int? AplicacaoId { get; set; }
        public IEnumerable<PermissaoViewModel> PermissaoSet { get; set; }
        /// <summary>
        /// Chave de ligação a coligada que o grupo pertence
        /// </summary>
        public short? ColigadaId { get; set; }
        /// <summary>
        /// Chave de ligação a filial que o grupo pertence
        /// </summary>
        public short? FilialId { get; set; }

        /// <summary>
        /// Aplicação que o grupo pertence
        /// </summary>
        public AplicacaoViewModel Aplicacao { get; set; }
        public bool Selecionado { get; set; }
        /// <summary>
        /// Campo determinado se o grupo é para todos usuários mesmo não estando adicionados fisicamente no grupo
        /// </summary>
        public bool Publico { get; set; }

        /// <summary>
        /// Se o grupo pertence a uma aplicação Abstrata então ele virá como Herdado as outras aplicações
        /// </summary>
        public bool Herdado { get; set; }
        /// <summary>
        /// Coleção de usuários que estão agrupados no grupo
        /// </summary>
        public IEnumerable<UsuarioViewModel> UsuarioSet { get; set; }
    }
}
