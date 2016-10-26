using LVSA.Base.Application.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Security.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public long Id { get; set; }
        [Obrigatorio]
        public string Codigo { get; set; }
        [Obrigatorio]
        public string Email { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }
        [DisplayName("Tipo")]
        public short? TipoUsuarioId { get; set; }
        public bool Ativo { get; set; }
        public bool Bloqueado { get; set; }
        [DisplayName("Setor")]
        public string Setor { get; set; }
        public byte[] Avatar { get; set; }
        public IEnumerable<UsuarioFilialViewModel> UsuarioFilialSet { get; set; }
        public TipoUsuarioViewModel TipoUsuario { get; set; }
        public IEnumerable<GrupoViewModel> GrupoSet { get; set; }
        private IEnumerable<PermissaoViewModel> permissaoset { get; set; }
        public IEnumerable<PermissaoViewModel> PermissaoSet
        {
            get
            {
                if (GrupoSet != null)
                    return GrupoSet.SelectMany(s => s.PermissaoSet);
                return null;
            }
            //get
            //{
            //    var p = permissaoset != null ? permissaoset.ToList() : new List<PermissaoViewModel> { };

            //    if (GrupoSet != null && GrupoSet.Count() > 0)
            //    {
            //        var g = GrupoSet.SelectMany(s => s.PermissaoSet).ToList();
            //        if (g.Count() > 0)
            //            p.AddRange(g);
            //    }

            //    return p;
            //}
            //set
            //{
            //    permissaoset = value;
            //}
        }

        public bool Selecionado { get; set; }
        public bool Desconectado { get; set; }
    }
}
