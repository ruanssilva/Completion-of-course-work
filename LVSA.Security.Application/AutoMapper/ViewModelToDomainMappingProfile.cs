using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Application.ViewModels;
using LVSA.Security.Domain;

namespace LVSA.Security.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappings_Security";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<AplicacaoViewModel, Aplicacao>();
            Mapper.CreateMap<GrupoViewModel, Grupo>();
            Mapper.CreateMap<PermissaoViewModel, Permissao>();
            Mapper.CreateMap<RecursoViewModel, Recurso>();
            Mapper.CreateMap<TipoRecursoViewModel, TipoRecurso>();
            Mapper.CreateMap<UsuarioViewModel, Usuario>();
            Mapper.CreateMap<TipoUsuarioViewModel, TipoUsuario>();
            Mapper.CreateMap<ParametroViewModel, Parametro>();
            Mapper.CreateMap<ConexaoViewModel, Conexao>();
            Mapper.CreateMap<ColigadaViewModel, Coligada>();
            Mapper.CreateMap<FilialViewModel, Filial>();
        }
    }
}
