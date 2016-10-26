using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace LVSA.Base.Application.ComponentModel.DataAnnotations
{
    public class Obrigatorio : RequiredAttribute
    {
        public Obrigatorio(string ErrorMessage = null)
        {
            this.ErrorMessage = ErrorMessage ?? "O campo {0} é obrigatório";
        }
    }
}
