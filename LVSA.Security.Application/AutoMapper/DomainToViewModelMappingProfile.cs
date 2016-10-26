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
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings_Security";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Aplicacao, AplicacaoViewModel>();
            Mapper.CreateMap<Grupo, GrupoViewModel>();
            Mapper.CreateMap<Permissao, PermissaoViewModel>();
            Mapper.CreateMap<Recurso, RecursoViewModel>();
            Mapper.CreateMap<TipoRecurso, TipoRecursoViewModel>();
            Mapper.CreateMap<Usuario, UsuarioViewModel>();
            Mapper.CreateMap<TipoUsuario, TipoUsuarioViewModel>();
            Mapper.CreateMap<Parametro, ParametroViewModel>();
            Mapper.CreateMap<Conexao, ConexaoViewModel>();
            Mapper.CreateMap<Coligada, ColigadaViewModel>();
            Mapper.CreateMap<Filial, FilialViewModel>();
        }
    }
}
