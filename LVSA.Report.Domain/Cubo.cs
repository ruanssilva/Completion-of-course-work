using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Domain
{
    public class Cubo : AuditoriaComAtivo, IFilialContexto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
        public int CategoriaCuboId { get; set; }
        public int ConsultaId { get; set; }
        public int InstrucaoId { get; set; }
        public string Descricao { get; set; }
        public string Icon { get; set; }
        public virtual Consulta Consulta { get; set; }
        public virtual CategoriaCubo CategoriaCubo { get; set; }
        public virtual Instrucao Instrucao { get; set; }
    }
}
