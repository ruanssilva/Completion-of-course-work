using LVSA.Base.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Global.Domain
{
    public class ColigadaComplemento : Auditoria
    {
        public int ColigadaId { get; set; }        
        public string Email { get; set; }
        public string RazaoSocial { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
    }
}
