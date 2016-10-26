using AutoMapper;
using LVSA.Report.Application.Interfaces;
using LVSA.Report.Application.ViewModels;
using LVSA.Report.Domain;
using LVSA.Report.Domain.Interfaces.Services;
using LVSA.Report.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace LVSA.Report.Application
{
    public class GrupoAppService : AppServiceBase<GrupoViewModel, Grupo, IGrupoService>, IGrupoAppService
    {
        private readonly GrupoAcessoCuboService _grupoAcessoCubo;

        public GrupoAppService(IGrupoService grupoService, GrupoAcessoCuboService grupoAcessoCubo)
            : base(grupoService)
        {
            _grupoAcessoCubo = grupoAcessoCubo;
        }

        public override IEnumerable<GrupoViewModel> Filtrar(System.Linq.Expressions.Expression<System.Func<Grupo, bool>> predicate)
        {
            IEnumerable<GrupoViewModel> model = base.Filtrar(predicate);


            foreach (var e in model)
            {
                var acessos = _grupoAcessoCubo.Find(f => f.GrupoId == e.Id).ToList();
                e.Cubos = Mapper.Map<IEnumerable<Cubo>, IEnumerable<CuboViewModel>>(acessos.Select(s1 => s1.Cubo)).ToList();
            }
                        

            //model = model.Select(s =>
            //{
            //    var teste = _grupoAcessoCubo.Find(f => f.GrupoId == s.Id).Select(s1 => s1.Cubo).ToList();
            //    s.Cubos = Mapper.Map<IEnumerable<Cubo>, IEnumerable<CuboViewModel>>(_grupoAcessoCubo.Find(f => f.GrupoId == s.Id).Select(s1 => s1.Cubo)).ToList();

            //    return s;
            //}).ToList();

            return model;
        }

        public override IEnumerable<GrupoViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public GrupoViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }

        public override GrupoViewModel Atualizar(GrupoViewModel model)
        {
            if (model.Cubos != null)
            {
                var all = _grupoAcessoCubo.Find(f => f.GrupoId == model.Id).ToList();

                foreach (var i in all.Where(w => !model.Cubos.Where(w1 => w1.Acesso).Select(s => s.Id).Contains(w.CuboId)))
                    _grupoAcessoCubo.Delete(i);

                foreach (var i in model.Cubos.Where(w => w.Acesso && !all.Select(s => s.CuboId).Contains(w.Id)))
                    _grupoAcessoCubo.Add(new GrupoAcessoCubo { CuboId = i.Id, GrupoId = model.Id });
            }

            return base.Atualizar(model);
        }
    }
}
