using AutoMapper;
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
    public class CuboAppService : AppServiceBase<CuboViewModel, Cubo, ICuboService>, ICuboAppService
    {
        public CuboAppService(ICuboService cuboService)
            : base(cuboService)
        {

        }

        public override IEnumerable<CuboViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public CuboViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).FirstOrDefault();
        }

        public override CuboViewModel Atualizar(CuboViewModel model)
        {
            Cubo entity = Service.Find(f => f.Id == model.Id).Single();

            entity.Ativo = model.Ativo;
            entity.Codigo = model.Codigo;
            entity.Descricao = model.Descricao;
            entity.CategoriaCuboId = model.CategoriaCuboId;
            entity.Icon = model.Icon;

            Service.Update(entity);

            return Mapper.Map<Cubo, CuboViewModel>(entity);
        }
    }
}
