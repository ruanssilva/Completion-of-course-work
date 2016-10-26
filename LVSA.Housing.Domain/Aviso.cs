using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;

namespace LVSA.Housing.Domain
{
    public class Aviso : AuditoriaComAtivo, IFilialContexto
    {
        public int Id { get; set; }
        public int SindicoId { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public DateTime PublicarEm { get; set; }
        public DateTime ExpirarEm { get; set; }

        public bool EnviaNotificacao { get; set; }
        public bool EnviaEmail { get; set; }

        public short FilialId { get; set; }
        public short ColigadaId { get; set; }

        public virtual Sindico Sindico { get; set; }
    }
}
