using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Security.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.AddProfile(new DomainToViewModelMappingProfile());
            Mapper.AddProfile(new ViewModelToDomainMappingProfile());
            //Mapper.Initialize(x =>
            //{
            //    x.AddProfile<DomainToViewModelMappingProfile>();
            //    x.AddProfile<ViewModelToDomainMappingProfile>();
            //});
        }
    }
}
