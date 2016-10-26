using AutoMapper;
using LVSA.Base.Application.Exceptions;
using LVSA.Global.Application.Interfaces;
using LVSA.Global.Application.ViewModels;
using LVSA.Global.Domain;
using LVSA.Global.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace LVSA.Global.Application
{
    public class PessoaFisicaComplementoAppService : AppServiceBase<PessoaFisicaComplementoViewModel, PessoaFisicaComplemento, IPessoaFisicaComplementoService>, IPessoaFisicaComplementoAppService
    {
        private readonly ICidadeAppService _cidadeAppService;

        public PessoaFisicaComplementoAppService(IPessoaFisicaComplementoService pessoaFisicaComplementoService, ICidadeAppService cidadeAppService)
            : base(pessoaFisicaComplementoService)
        {
            _cidadeAppService = cidadeAppService;
        }

        public PessoaFisicaComplementoViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.PessoaId == id).SingleOrDefault();
        }

        public override IEnumerable<PessoaFisicaComplementoViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public override PessoaFisicaComplementoViewModel Atualizar(PessoaFisicaComplementoViewModel model)
        {
            PessoaFisicaComplemento entity = Service.Find(f => f.PessoaId == model.PessoaId).SingleOrDefault();
            if (entity == null)
                throw new NoRecordsFoundException("Pessoa não existe");

            entity.UsuarioId = model.UsuarioId;
            entity.Facebook = model.Facebook;
            entity.Instagram = model.Instagram;
            entity.GooglePlus = model.GooglePlus;
            entity.RacaCorId = model.RacaCorId;
            entity.CidadeNaturalidadeId = model.CidadeNaturalidadeId;
            entity.Telefone1 = model.Telefone1;
            entity.Telefone2 = model.Telefone2;
            entity.Email = model.Email;
            entity.EscolaridadeId = model.EscolaridadeId;
            entity.TitulacaoId = model.TitulacaoId;

            if (model.ImagemId > 0)
                entity.ImagemId = model.ImagemId;

            Service.Update(entity);

            return Mapper.Map<PessoaFisicaComplemento, PessoaFisicaComplementoViewModel>(entity);
        }

       
    }

}
