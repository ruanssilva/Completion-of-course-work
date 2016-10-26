
using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Housing.Domain
{
    public class Morador : AuditoriaComAtivo, IFilialContexto
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public int MoradiaId { get; set; }
        public virtual Moradia Moradia { get; set; }
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
        public virtual Condominio Condominio { get; set; }
        public bool ResponsavelFinanceiro { get; set; }

    }
}
