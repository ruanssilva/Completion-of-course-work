using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;

namespace LVSA.Financial.Domain
{
    public class CCusto : AuditoriaComExclusaoLogicaComAtivo, IColigadaContexto
    {
        public int Id { get; set; }
        public int? CategoriaCCustoId { get; set; }
        public string Codigo { get; set; }
        public int? ContaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual CategoriaCCusto CategoriaCCusto { get; set; }
        public virtual Conta Conta { get; set; }

        public short ColigadaId { get; set; }
    }
}
