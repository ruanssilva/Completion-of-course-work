using AutoMapper;
using LVSA.Farm.Application.Interfaces;
using LVSA.Farm.Application.ViewModels;
using LVSA.Farm.Domain;
using LVSA.Farm.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Application
{
    public class TerrenoAppService : AppServiceBase<TerrenoViewModel, Terreno, ITerrenoService>, ITerrenoAppService
    {
        public TerrenoAppService(ITerrenoService terrenoService)
            : base(terrenoService)
        {

        }

        public TerrenoViewModel Obter()
        {
            return Filtrar(f => true).SingleOrDefault();
        }

        public override TerrenoViewModel Atualizar(TerrenoViewModel model)
        {
            if (Obter() == null)
                Incluir(model);

            var entity = Service.Find(f => f.ColigadaId == Seguranca.ColigadaId && f.FilialId == Seguranca.FilialId).Single();

            entity.Comprimento = model.Comprimento;
            entity.Descricao = model.Descricao;
            entity.M2 = model.M2;
            entity.Nome = model.Nome;
            entity.Largura = model.Largura;

            entity.RECCREATEDBY = Seguranca.CODUSUARIO;

            Service.Update(entity);

            return Mapper.Map<Terreno, TerrenoViewModel>(entity);
        }
    }
}
