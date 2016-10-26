using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System.Collections.Generic;

namespace LVSA.Report.Domain
{
    public class Consulta : AuditoriaComExclusaoLogicaComAtivo, IColigadaContexto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int CategoriaConsultaId { get; set; }
        public short ColigadaId { get; set; }
        public string TSQL { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Cubo> Cubos { get; set; }
        public virtual CategoriaConsulta CategoriaConsulta { get; set; }
    }
}
