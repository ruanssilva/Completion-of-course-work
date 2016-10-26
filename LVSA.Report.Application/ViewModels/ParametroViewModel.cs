using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Application.ViewModels
{
    public class ParametroViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(65)]
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        [Required]
        [MaxLength(65)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [MaxLength(65)]
        [Display(Name = "DataType")]
        public string DataType { get; set; }
        [MaxLength(65)]
        [Display(Name = "Ícone")]
        public string Icon { get; set; }
        [MaxLength(65)]
        [Display(Name = "Regex")]
        public string Regex { get; set; }
        [Display(Name = "Número")]
        public int Numero { get; set; }
        private dynamic _valor { get; set; }
        [Required]
        public dynamic Valor
        {
            get
            {
                
                if (DataType != null && Type.GetType(DataType) == typeof(bool))
                    return _valor != null && _valor ? "1" : "0";

                return _valor ?? "''";
            }
            set
            {
                if (value is string[] && ((string[])value).Count() == 1)
                    value = value[0];

                if (Type.GetType(DataType) == typeof(DateTime))
                {
                    if (!string.IsNullOrEmpty(value))
                        _valor = DateTime.Parse(value).ToString("yyyy-MM-dd");
                }
                else if (Type.GetType(DataType) == typeof(TimeSpan))
                {
                    if (!string.IsNullOrEmpty(value))
                        _valor = TimeSpan.Parse(value).ToString();
                }
                else if (Type.GetType(DataType) == typeof(bool))
                {
                    if (value is string)
                        value = value == "true";
                    else
                        value = false;

                    _valor = value;
                }
                else
                    _valor = value;

            }
        }
        [MaxLength(65)]
        [Display(Name = "Máscara")]
        public string Mask { get; set; }
        [Display(Name = "Consulta")]
        public string Consulta { get; set; }
        [Display(Name = "Multivalorável")]
        public bool Multivaloravel { get; set; }
        [MaxLength(255)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public List<ValorViewModel> ValorSet { get; set; }
    }
}
