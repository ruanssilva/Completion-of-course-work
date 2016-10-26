using AutoMapper;
using LVSA.Housing.Application.ViewModels;
using LVSA.Housing.Domain;

namespace LVSA.Housing.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Condominio, CondominioViewModel>();
            Mapper.CreateMap<Moradia, MoradiaViewModel>();
            Mapper.CreateMap<Morador, MoradorViewModel>();
            Mapper.CreateMap<Bloco, BlocoViewModel>();
            Mapper.CreateMap<Sindico, SindicoViewModel>();
            Mapper.CreateMap<CustoMoradia, CustoMoradiaViewModel>();
            Mapper.CreateMap<Aviso, AvisoViewModel>();
            Mapper.CreateMap<Reuniao, ReuniaoViewModel>();
            Mapper.CreateMap<Multa, MultaViewModel>();
            Mapper.CreateMap<MultaMorador, MultaMoradorViewModel>();
        }
    }
}
