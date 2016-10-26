using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LVSA.Farm.Domain
{
    public class Retrato : AuditoriaComExclusaoLogica, IFilialContexto
    {
        public long Id { get; set; }
        public byte[] Valor { get; set; }
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
        public int? PastoId { get; set; }
        public int? PiqueteId { get; set; }
        public int? RacaId { get; set; }
        public int? TipoAnimalId { get; set; }
        public long? AnimalId { get; set; }
        public int? DoencaId { get; set; }
        public long? DiagnosticoId { get; set; }
    }
}
