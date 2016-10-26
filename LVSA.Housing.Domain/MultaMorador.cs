using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;

namespace LVSA.Housing.Domain
{
    public class MultaMorador : AuditoriaComExclusaoLogica, IColigadaContexto
    {
        public int Id { get; set; }
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
        public int MoradorId { get; set; }
        public int MultaId { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public decimal Juros { get; set; }
        public DateTime DataReferencia { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public virtual Morador Morador { get; set; }
        public virtual Multa Multa { get; set; }
    }
}
