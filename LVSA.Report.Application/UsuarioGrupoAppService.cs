using LVSA.Report.Application.Interfaces;
using LVSA.Report.Application.ViewModels;
using LVSA.Report.Domain;
using LVSA.Report.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Application
{
    public class UsuarioGrupoAppService : AppServiceBase<UsuarioGrupoViewModel, UsuarioGrupo, IUsuarioGrupoService>, IUsuarioGrupoAppService
    {
        public UsuarioGrupoAppService(IUsuarioGrupoService usuarioGrupoService)
            : base(usuarioGrupoService)
        {

        }

        public UsuarioGrupoViewModel ObterPorId(int id)
        {
            throw new NotSupportedException();
        }

        public override IEnumerable<UsuarioGrupoViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public override void Remover(UsuarioGrupoViewModel model)
        {
            UsuarioGrupo entity = Service.Find(f => f.GrupoId == model.GrupoId && f.UsuarioId == model.UsuarioId).SingleOrDefault();

            if (entity == null)
                throw new ArgumentNullException("entity");

            Service.Delete(entity);
        }
    }
}
