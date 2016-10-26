using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Application.ComponentModel.DataAnnotations;

namespace LVSA.Security.Application.ViewModels
{
    public class AplicacaoViewModel
    {
        /// <summary>
        /// Chave única da aplicação
        /// </summary>
        [Obrigatorio]
        public int Id { get; set; }
        /// <summary>
        /// Sigla da aplicação para abreviaturas
        /// </summary>
        [Obrigatorio]
        [ComprimentoMaximo(8)]
        [DisplayName("Sigla")]
        public string Sigla { get; set; }
        /// <summary>
        /// Nome da aplicação
        /// </summary>
        [Obrigatorio]
        [ComprimentoMaximo(65)]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        /// <summary>
        /// Nome de exibição da aplicação ao usuário 
        /// </summary>
        [Obrigatorio]
        [ComprimentoMaximo(65)]
        [DisplayName("Exibição")]
        public string Exibicao { get; set; }
        /// <summary>
        /// Breve descrição de apresentação da Aplicação
        /// </summary>
        [ComprimentoMaximo(255)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        /// <summary>
        /// Link de hospedagem da aplicação
        /// </summary>
        [ComprimentoMaximo(255)]
        [DisplayName("Url hospedagem")]
        public string Link { get; set; }
        /// <summary>
        /// Ícone da aplicação 
        /// </summary>
        [ComprimentoMaximo(65)]
        [DisplayName("Ícone")]
        public string Icon { get; set; }
        /// <summary>
        /// Imagem para logo da aplicação
        /// </summary>
        [DisplayName("Logo")]
        public byte[] Logo { get; set; }
        /// <summary>
        /// Tipo/formato da imagem de logo da aplicação
        /// </summary>
        [ComprimentoMaximo(65)]
        public string ContentType { get; set; }
        /// <summary>
        /// Status da aplicação
        /// </summary>
        [DisplayName("Ativo")]
        public bool Ativo { get; set; }
        /// <summary>
        /// Se a aplicação é apenas uma referência de recursos e não será acessada diretamente
        /// </summary>
        [DisplayName("Abstrata")]
        public bool Abstrata { get; set; }
        [DisplayName("Desktop")]
        public bool Desktop { get; set; }
        [DisplayName("Target _blank")]
        public bool Blank { get; set; }
        public IEnumerable<RecursoViewModel> RecursoSet
        {
            get
            {
                if (AplicacaoSet != null && AplicacaoSet.Count() > 0)
                {
                    var recursos = AplicacaoSet.SelectMany(s => s.RecursoSet).ToList();

                    recursos.ForEach(f => { f.Herdado = true; });

                    recursos.AddRange(_recursoset);
                    return recursos;
                }
                return _recursoset;
            }
            set { _recursoset = value; }
        }
        private IEnumerable<RecursoViewModel> _recursoset { get; set; }
        public int[] ParametroIdSet { get; set; }
        public IEnumerable<ParametroViewModel> ParametroSet { get; set; }
        [DisplayName("Aplicações dep.")]
        public int[] AplicacaoIdSet { get; set; }
        public IEnumerable<AplicacaoViewModel> AplicacaoSet { get; set; }
        private IEnumerable<GrupoViewModel> _gruposet { get; set; }
        public IEnumerable<GrupoViewModel> GrupoSet
        {
            get
            {
                if (AplicacaoSet != null && AplicacaoSet.Count() > 0)
                {
                    var grupos = AplicacaoSet.SelectMany(s => s.GrupoSet).ToList();

                    grupos.ForEach(f => { f.Herdado = true; });

                    grupos.AddRange(_gruposet ?? new List<GrupoViewModel> { });
                    return grupos;
                }
                return _gruposet;
            }
            set { _gruposet = value; }
        }
        [DisplayName("Selecionado")]
        public bool Selecionado { get; set; }
        [DisplayName("Vencimento")]
        public DateTime? Vencimento { get; set; }
    }
}
