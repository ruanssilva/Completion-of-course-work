
using AutoMapper;
namespace LVSA.Housing.Application.AutoMapper
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
