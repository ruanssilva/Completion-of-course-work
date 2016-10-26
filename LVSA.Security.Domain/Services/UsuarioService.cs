using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain.Services;
using LVSA.Security.Domain.Interfaces.Repository;
using LVSA.Security.Domain.Interfaces.Services;

namespace LVSA.Security.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        public UsuarioService(IUsuarioRepository repository)
            : base(repository)
        {

        }

        public Usuario GetByCodigo(string codigo)
        {
            return _repository.Find(f => f.Nome == codigo).SingleOrDefault();
        }


        public Usuario GetById(long id)
        {
            return _repository.Find(f => f.Id == id).SingleOrDefault();
        }
    }
}
