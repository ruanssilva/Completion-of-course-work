using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Noticia.Application.ViewModels;
using LVSA.Noticia.Domain;

namespace LVSA.Noticia.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Noticia.Domain.Noticia, NoticiaViewModel>();
            Mapper.CreateMap<Imagem, ImagemViewModel>();
        }
    }
}
