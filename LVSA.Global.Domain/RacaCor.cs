﻿using LVSA.Base.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Global.Domain
{
    public class RacaCor : Auditoria
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public ICollection<PessoaFisicaComplemento> PessoasFisica { get; set; }
    }
}
