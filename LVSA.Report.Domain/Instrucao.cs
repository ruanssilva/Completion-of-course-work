using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Domain
{
    public class Instrucao : AuditoriaComExclusaoLogicaComAtivo, IColigadaContexto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public short ColigadaId { get; set; }
        public int CategoriaInstrucaoId { get; set; }
        public string Code { get; set; }
        public string Descricao { get; set; }
        public virtual CategoriaInstrucao CategoriaInstrucao { get; set; }
        public virtual ICollection<Cubo> Cubos { get; set; }
    }
}
