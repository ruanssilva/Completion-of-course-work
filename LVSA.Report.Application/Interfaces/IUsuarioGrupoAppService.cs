using LVSA.Report.Application.ViewModels;
using LVSA.Report.Domain;

namespace LVSA.Report.Application.Interfaces
{
    public interface IUsuarioGrupoAppService : IAppServiceBase<UsuarioGrupoViewModel,UsuarioGrupo>
    {
        UsuarioGrupoViewModel ObterPorId(int id);
    }
}
