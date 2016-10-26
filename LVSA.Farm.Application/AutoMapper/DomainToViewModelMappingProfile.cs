using AutoMapper;
using LVSA.Farm.Application.ViewModels;
using LVSA.Farm.Domain;

namespace LVSA.Farm.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Terreno, TerrenoViewModel>();
            Mapper.CreateMap<Pasto, PastoViewModel>();
            Mapper.CreateMap<Piquete, PiqueteViewModel>();
            Mapper.CreateMap<Retrato, RetratoViewModel>();
            Mapper.CreateMap<TipoAnimal, TipoAnimalViewModel>();
            Mapper.CreateMap<Raca, RacaViewModel>();
            Mapper.CreateMap<TipoMedicamento, TipoMedicamentoViewModel>();
            Mapper.CreateMap<Medicamento, MedicamentoViewModel>();
            Mapper.CreateMap<Animal, AnimalViewModel>();
            Mapper.CreateMap<Doenca, DoencaViewModel>();
            Mapper.CreateMap<LocalPesagem, LocalPesagemViewModel>();
            Mapper.CreateMap<Tratamento, TratamentoViewModel>();
            Mapper.CreateMap<Dosagem, DosagemViewModel>();
            Mapper.CreateMap<Diagnostico, DiagnosticoViewModel>();
            Mapper.CreateMap<Ordenha, OrdenhaViewModel>();

        }
    }
}
