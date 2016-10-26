using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Application.ComponentModel.DataAnnotations;

namespace LVSA.Security.Application.ViewModels
{
    public class RecursoViewModel
    {
        public long Id { get; set; }
        [Obrigatorio]
        [DisplayName("Aplicação")]
        public int AplicacaoId { get; set; }
        [Obrigatorio]
        [DisplayName("Tipo de recurso")]
        public short TipoRecursoId { get; set; }
        [Obrigatorio]
        [ComprimentoMaximo(65)]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        [Obrigatorio]
        [ComprimentoMaximo(65)]
        [DisplayName("Exibição")]
        public string Exibicao { get; set; }
        [ComprimentoMaximo(65)]
        [DisplayName("Controller")]
        public string Controller { get; set; }
        [ComprimentoMaximo(65)]
        [DisplayName("Action")]
        public string Action { get; set; }
        [Obrigatorio]
        [ComprimentoMaximo(65)]
        [DisplayName("Ícone")]
        public string Icon { get; set; }
        [Obrigatorio]
        [ComprimentoMaximo(255)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        [ComprimentoMaximo(255)]
        [DisplayName("Tags")]
        public string Tags { get; set; }
        /// <summary>
        /// Peso de ordenação do recurso
        /// </summary>
        public decimal? Peso { get; set; }
        [DisplayName("Ativo")]
        public bool Ativo { get; set; }
        [DisplayName("Recurso pai")]
        public long? RecursoPaiId { get; set; }
        public RecursoViewModel RecursoPai { get; set; }
        public TipoRecursoViewModel TipoRecurso { get; set; }
        public AplicacaoViewModel Aplicacao { get; set; }
        public List<RecursoViewModel> RecursoSet { get; set; }
        [DisplayName("Selecionado")]
        public bool Selecionado { get; set; }
        public bool Herdado { get; set; }
    }
}
