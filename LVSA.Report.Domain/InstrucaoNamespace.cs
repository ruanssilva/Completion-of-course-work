using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;

namespace LVSA.Report.Domain
{
    public class InstrucaoNamespace : Auditoria, IColigadaContexto
    {
        public int InstrucaoId { get; set; }
        public short ColigadaId { get; set; }
        public int NamespaceId { get; set; }
        public virtual Instrucao Instrucao { get; set; }
        public virtual Namespace Namespace { get; set; }
    }
}
