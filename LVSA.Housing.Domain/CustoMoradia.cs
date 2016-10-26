
using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;

namespace LVSA.Housing.Domain
{
    public class CustoMoradia : AuditoriaComExclusaoLogicaComAtivo, IFilialContexto
    {
        public int Id { get; set; }
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
        public int MoradiaId { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public decimal Juros { get; set; }
        public string Descricao { get; set; }
        public DateTime DataReferencia { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public virtual Moradia Moradia { get; set; }
    }
}
