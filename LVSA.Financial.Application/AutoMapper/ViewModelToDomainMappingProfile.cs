using AutoMapper;
using LVSA.Financial.Application.ViewModels;
using LVSA.Financial.Domain;

namespace LVSA.Financial.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CCustoViewModel, CCusto>();
            Mapper.CreateMap<CategoriaCCustoViewModel, CategoriaCCusto>();
            Mapper.CreateMap<LancamentoViewModel, Lancamento>();
            Mapper.CreateMap<NFiscalViewModel, NFiscal>();
            Mapper.CreateMap<TipoContaViewModel, TipoConta>();
            Mapper.CreateMap<ContaViewModel, Conta>();
        }
    }
}
