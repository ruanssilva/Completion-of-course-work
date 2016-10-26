using AutoMapper;
using LVSA.Farm.Application.ViewModels;
using LVSA.Farm.Domain;

namespace LVSA.Farm.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<TerrenoViewModel, Terreno>();
            Mapper.CreateMap<PastoViewModel, Pasto>();
            Mapper.CreateMap<PiqueteViewModel, Piquete>();
            Mapper.CreateMap<RetratoViewModel, Retrato>();
            Mapper.CreateMap<TipoAnimalViewModel, TipoAnimal>();
            Mapper.CreateMap<RacaViewModel, Raca>();
            Mapper.CreateMap<TipoMedicamentoViewModel, TipoMedicamento>();
            Mapper.CreateMap<MedicamentoViewModel, Medicamento>();
            Mapper.CreateMap<AnimalViewModel, Animal>();
            Mapper.CreateMap<DoencaViewModel, Doenca>();
            Mapper.CreateMap<TratamentoViewModel, Tratamento>();
            Mapper.CreateMap<DosagemViewModel, Dosagem>();
            Mapper.CreateMap<DiagnosticoViewModel, Diagnostico>();
            Mapper.CreateMap<OrdenhaViewModel, Ordenha>();
        }
    }
}
