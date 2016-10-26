using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;

namespace LVSA.Financial.Domain
{
    public class CategoriaCCusto : AuditoriaComAtivo, IColigadaContexto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public short ColigadaId { get; set; }
    }
}
