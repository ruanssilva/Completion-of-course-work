using LVSA.Base.Domain.Services;
using LVSA.Global.Domain.Interfaces.Repository;
using LVSA.Global.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LVSA.Global.Domain.Services
{
    public class PessoaFisicaService : ServiceBase<PessoaFisica>, IPessoaFisicaService
    {

        public PessoaFisicaService(IPessoaFisicaRepository pessoafisicaRepository)
            : base(pessoafisicaRepository)
        {

        }
        

    }
}
