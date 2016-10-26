using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Base.Application.ComponentModel.DataAnnotations
{
    public class Comprimento : StringLengthAttribute
    {
        public Comprimento(int maxlenght, int minlenght)
            : base(maxlenght)
        {
            this.MinimumLength = minlenght;
            this.ErrorMessage = "O campo {0} deve ser uma cadeia de caracteres com no mínimo {1} e no máximo {2} de comprimento.";
        }
    }
}
