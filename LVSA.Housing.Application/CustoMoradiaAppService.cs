using AutoMapper;
using LVSA.Housing.Application.Interfaces;
using LVSA.Housing.Application.ViewModels;
using LVSA.Housing.Domain;
using LVSA.Housing.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LVSA.Housing.Application
{
    public class CustoMoradiaAppService : AppServiceBase<CustoMoradiaViewModel, CustoMoradia, ICustoMoradiaService>, ICustoMoradiaAppService
    {
        public CustoMoradiaAppService(ICustoMoradiaService custoMoradiaService)
            : base(custoMoradiaService)
        {

        }

        public override IEnumerable<CustoMoradiaViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public CustoMoradiaViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }

        public override CustoMoradiaViewModel Atualizar(CustoMoradiaViewModel model)
        {
            CustoMoradia entity = Service.Find(f=> f.Id == model.Id).SingleOrDefault();

            //verifica se é um registro da filial logada
            if (entity.ColigadaId != Seguranca.ColigadaId || entity.FilialId != Seguranca.FilialId)
                throw new FieldAccessException();

            //colunas permitidas para atualizar
            entity.DataPagamento = model.DataPagamento;
            entity.Juros = model.Juros;

            Service.Update(entity);

            return Mapper.Map<CustoMoradia, CustoMoradiaViewModel>(entity);
        }
    }
}
