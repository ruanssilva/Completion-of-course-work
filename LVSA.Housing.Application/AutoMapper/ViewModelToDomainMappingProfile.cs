using AutoMapper;
using LVSA.Housing.Application.ViewModels;
using LVSA.Housing.Domain;

namespace LVSA.Housing.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CondominioViewModel, Condominio>();
            Mapper.CreateMap<MoradiaViewModel, Moradia>();
            Mapper.CreateMap<MoradorViewModel, Morador>();
            Mapper.CreateMap<BlocoViewModel, Bloco>();
            Mapper.CreateMap<SindicoViewModel, Sindico>();
            Mapper.CreateMap<CustoMoradiaViewModel, CustoMoradia>();
            Mapper.CreateMap<AvisoViewModel, Aviso>();
            Mapper.CreateMap<ReuniaoViewModel, Reuniao>();
            Mapper.CreateMap<MultaViewModel, Multa>();
            Mapper.CreateMap<MultaMoradorViewModel, MultaMorador>();
        }
    }
}
