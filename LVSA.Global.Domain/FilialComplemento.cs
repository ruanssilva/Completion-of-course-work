
using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
namespace LVSA.Global.Domain
{
    public class FilialComplemento : Auditoria, IColigadaContexto
    {
        public int FilialId { get; set; }
        public string Email { get; set; }
        public string RazaoSocial { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public short ColigadaId { get; set; }
    }
}
