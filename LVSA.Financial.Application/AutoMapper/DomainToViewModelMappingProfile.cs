using AutoMapper;
using LVSA.Financial.Application.ViewModels;
using LVSA.Financial.Domain;

namespace LVSA.Financial.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CCusto, CCustoViewModel>();
            Mapper.CreateMap<CategoriaCCusto, CategoriaCCustoViewModel>();
            Mapper.CreateMap<Lancamento, LancamentoViewModel>();
            Mapper.CreateMap<NFiscal, NFiscalViewModel>();
            Mapper.CreateMap<TipoConta, TipoContaViewModel>();
            Mapper.CreateMap<Conta, ContaViewModel>();
        }
    }
}
