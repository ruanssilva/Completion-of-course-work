using LVSA.Base.Domain;
using System.Collections.Generic;

namespace LVSA.Global.Domain
{
    public class Estado : Auditoria
    {
        public int Id { get; set; }
        public int PaisId { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string SiglaUF { get; set; }
        public virtual ICollection<Cidade> Cidades { get; set; }
        public virtual Pais Pais { get; set; }
    }
}
