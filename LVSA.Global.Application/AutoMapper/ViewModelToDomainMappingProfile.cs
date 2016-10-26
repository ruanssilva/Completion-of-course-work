using AutoMapper;
using LVSA.Global.Application.ViewModels;
using LVSA.Global.Domain;

namespace LVSA.Global.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<BairroViewModel, Bairro>();
            Mapper.CreateMap<CidadeViewModel, Cidade>();
            Mapper.CreateMap<ColigadaComplementoViewModel, ColigadaComplemento>();
            Mapper.CreateMap<EscolaridadeViewModel, Escolaridade>();
            Mapper.CreateMap<EstadoViewModel, Estado>();
            Mapper.CreateMap<FilialComplementoViewModel, FilialComplemento>();
            Mapper.CreateMap<ImagemViewModel, Imagem>();
            Mapper.CreateMap<PessoaFisicaViewModel, PessoaFisica>();
            Mapper.CreateMap<PessoaJuridicaViewModel, PessoaJuridica>();
            Mapper.CreateMap<RacaCorViewModel, RacaCor>();
            Mapper.CreateMap<TitulacaoViewModel, Titulacao>();
            Mapper.CreateMap<PaisViewModel, Pais>();
            Mapper.CreateMap<PessoaFisicaComplementoViewModel, PessoaFisicaComplemento>();
        }
    }
}
