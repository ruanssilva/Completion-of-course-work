
using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
namespace LVSA.Global.Domain
{
    public class Imagem : AuditoriaComExclusaoLogica, IColigadaContexto
    {
        public int Id { get; set; }
        public short ColigadaId { get; set; }
        public string Nome { get; set; }
        public string ContentType { get; set; }
        public byte[] Valor { get; set; }        
    }
}
