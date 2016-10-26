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
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<NoticiaViewModel, Noticia.Domain.Noticia>();
            Mapper.CreateMap<ImagemViewModel, Imagem>();

        }
    }
}
