using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Application.ComponentModel.DataAnnotations;

namespace LVSA.Security.Application.ViewModels
{
    public class PermissaoViewModel
    {
        public long Id { get; set; }
        [DisplayName("Recurso")]
        public long? RecursoId { get; set; }
        public long? RelatorioId { get; set; }
        [DisplayName("Grupo")]
        public long? GrupoId { get; set; }
        [DisplayName("Usuário")]
        public long? UsuarioId { get; set; }
        public RecursoViewModel Recurso { get; set; }
        public GrupoViewModel Grupo { get; set; }
        public UsuarioViewModel Usuario { get; set; }
        [DisplayName("Selecionado")]
        public bool Selecionado { get; set; }
        [DisplayName("Visualizar")]
        public bool Read { get; set; }
        [DisplayName("Inserir")]
        public bool Write { get; set; }
        [DisplayName("Alterar")]
        public bool Rewrite { get; set; }
        [DisplayName("Excluir")]
        public bool Delete { get; set; }
    }
}
