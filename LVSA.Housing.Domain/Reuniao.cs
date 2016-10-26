
using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Housing.Domain
{
    public class Reuniao : AuditoriaComExclusaoLogicaComAtivo, IFilialContexto
    {
        public int Id { get; set; }
        public int SindicoId { get; set; }
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
        public string Assunto { get; set; }
        public string Descricao { get; set; }
        public string Ata { get; set; }
        public DateTime Quando { get; set; }
        public string Onde { get; set; }
        public bool Cancelado { get; set; }
        public virtual ICollection<Presenca> PresencaSet { get; set; }
        public virtual Sindico Sindico { get; set; }
    }
}
