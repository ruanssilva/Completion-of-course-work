using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;

namespace LVSA.Housing.Domain
{
    public class Presenca : Auditoria, IFilialContexto
    {
        public long MoradorId { get; set; }
        public long ReuniaoId { get; set; }
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
    }
}