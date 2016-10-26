using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Application.Interfaces;
using LVSA.Security.Application.ViewModels;
using LVSA.Security.Domain;
using LVSA.Security.Domain.Interfaces.Services;

namespace LVSA.Security.Application
{
    public class ConexaoAppService : AppServiceBase<ConexaoViewModel, Conexao, IConexaoService>, IConexaoAppService
    {
        public ConexaoAppService(IConexaoService conexaoService)
            : base(conexaoService)
        {

        }

        public override IEnumerable<ConexaoViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public ConexaoViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).FirstOrDefault();
        }
    }
}
