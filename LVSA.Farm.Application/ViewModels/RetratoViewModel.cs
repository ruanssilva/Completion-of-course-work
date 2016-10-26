using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Application.ViewModels
{
    public class RetratoViewModel
    {
        public long Id { get; set; }
        public byte[] Valor { get; set; }
        public int? PastoId { get; set; }
        public int? PiqueteId { get; set; }
        public int? RacaId { get; set; }
        public int? TipoAnimalId { get; set; }        
        public long? AnimalId { get; set; }
        public int? DoencaId { get; set; }
        public long? DiagnosticoId { get; set; }
    }
}
