using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Financial.Application.ViewModels
{
    public class ContaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public short TipoContaId { get; set; }
        public bool Ativo { get; set; }
        public virtual TipoContaViewModel TipoConta { get; set; }
        public virtual IEnumerable<CCustoViewModel> CCustoSet { get; set; }
    }
}
