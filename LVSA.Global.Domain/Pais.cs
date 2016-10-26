
using LVSA.Base.Domain;
using System.Collections.Generic;
namespace LVSA.Global.Domain
{
    public class Pais : Auditoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public virtual ICollection<Estado> Estados { get; set; }
    }
}
