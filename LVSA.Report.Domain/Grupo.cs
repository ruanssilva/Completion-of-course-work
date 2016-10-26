using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;

namespace LVSA.Report.Domain
{
    public class Grupo : AuditoriaComAtivo, IFilialContexto
    {
        public int Id { get; set; }
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
