using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Domain
{
    public class Animal : AuditoriaComExclusaoLogica, IFilialContexto
    {
        public long Id { get; set; }
        public int TipoAnimalId { get; set; }
        public int? RacaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int? Quantidade { get; set; }
        public DateTime? Nascimento { get; set; }
        public decimal? Peso { get; set; }
        public decimal? Comprimento { get; set; }
        public decimal? Largura { get; set; }
        public string Observacao { get; set; }
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
        public virtual ICollection<Retrato> RetratoSet { get; set; }
        public virtual ICollection<Medicacao> MedicacaoSet { get; set; }
        public virtual ICollection<Diagnostico> DiagnosticoSet { get; set; }
        public virtual TipoAnimal TipoAnimal { get; set; }
        public virtual Raca Raca { get; set; }

    }
}
