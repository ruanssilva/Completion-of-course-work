using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;

namespace LVSA.Financial.Domain
{
    public class NFiscal : AuditoriaComExclusaoLogica, IFilialContexto
    {        
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public DateTime DataEmissao { get; set; }
        public string Numero { get; set; }
        public string Serie { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string Cnpj { get; set; }
        public Decimal ValorTotal { get; set; }
        public byte[] Anexo { get; set; }
        public short FilialId { get; set; }
        public short ColigadaId { get; set; }
    }
}
