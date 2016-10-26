using AutoMapper;
using LVSA.Report.Application.ViewModels;
using LVSA.Report.Domain;

namespace LVSA.Report.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ConsultaViewModel, Consulta>();
            Mapper.CreateMap<ParametroViewModel, Parametro>();
            Mapper.CreateMap<InstrucaoViewModel, Instrucao>();
            Mapper.CreateMap<CuboViewModel, Cubo>();
            Mapper.CreateMap<CategoriaCuboViewModel, CategoriaCubo>();
            Mapper.CreateMap<CategoriaConsultaViewModel, CategoriaConsulta>();
            Mapper.CreateMap<CategoriaInstrucaoViewModel, CategoriaInstrucao>();
            Mapper.CreateMap<GrupoViewModel, Grupo>();
            Mapper.CreateMap<UsuarioGrupoViewModel, UsuarioGrupo>();
        }
    }
}
