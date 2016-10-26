using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;

namespace LVSA.Financial.Domain
{
    public class Lancamento : AuditoriaComExclusaoLogica, IFilialContexto
    {
        public int Id { get; set; }
        public int? NFiscalId { get; set; }
        public int CCustoId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataLancamento { get; set; }
        public string Descricao { get; set; }
        public int? ContaId { get; set; }
        public short FilialId { get; set; }
        public short ColigadaId { get; set; }
        public virtual CCusto CCusto { get; set; }
        public virtual NFiscal NFiscal { get; set; }
        public virtual Conta Conta { get; set; }
        public string Identificador { get; set; }
    }
}
