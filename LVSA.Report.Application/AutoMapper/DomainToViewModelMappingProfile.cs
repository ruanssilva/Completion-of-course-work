using AutoMapper;
using LVSA.Report.Application.ViewModels;
using LVSA.Report.Domain;

namespace LVSA.Report.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Consulta, ConsultaViewModel>();
            Mapper.CreateMap<Parametro, ParametroViewModel>();
            Mapper.CreateMap<Instrucao, InstrucaoViewModel>();
            Mapper.CreateMap<Cubo, CuboViewModel>();
            Mapper.CreateMap<CategoriaConsulta, CategoriaConsultaViewModel>();
            Mapper.CreateMap<CategoriaCubo, CategoriaCuboViewModel>();
            Mapper.CreateMap<CategoriaInstrucao, CategoriaInstrucaoViewModel>();
            Mapper.CreateMap<Grupo, GrupoViewModel>();
            Mapper.CreateMap<UsuarioGrupo, UsuarioGrupoViewModel>();
        }
    }
}
