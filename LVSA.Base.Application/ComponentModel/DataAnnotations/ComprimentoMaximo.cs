using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Base.Application.ComponentModel.DataAnnotations
{
    public class ComprimentoMaximo : MaxLengthAttribute
    {
        public ComprimentoMaximo(int lenght, string ErrorMessage = null)
            : base(lenght)
        {
            this.ErrorMessage = ErrorMessage ?? "O campo {0} deve ser uma cadeia de caracteres no máximo de {1} de comprimento.";
        }
    }
}
