using AutoMapper;
using LVSA.Global.Application.ViewModels;
using LVSA.Global.Domain;

namespace LVSA.Global.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Bairro, BairroViewModel>();
            Mapper.CreateMap<Cidade, CidadeViewModel>();
            Mapper.CreateMap<ColigadaComplemento, ColigadaComplementoViewModel>();
            Mapper.CreateMap<Escolaridade, EscolaridadeViewModel>();
            Mapper.CreateMap<Estado, EstadoViewModel>();
            Mapper.CreateMap<FilialComplemento, FilialComplementoViewModel>();
            Mapper.CreateMap<Imagem, ImagemViewModel>();
            Mapper.CreateMap<PessoaFisica, PessoaFisicaViewModel>();
            Mapper.CreateMap<PessoaJuridica, PessoaJuridicaViewModel>();
            Mapper.CreateMap<RacaCor, RacaCorViewModel>();
            Mapper.CreateMap<Titulacao, TitulacaoViewModel>();
            Mapper.CreateMap<Pais, PaisViewModel>();
            Mapper.CreateMap<PessoaFisicaComplemento, PessoaFisicaComplementoViewModel>();
        }
    }
}
