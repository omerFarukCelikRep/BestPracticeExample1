using Api.Data.Models;
using AutoMapper;
using Models;

namespace Api.Extensions
{
    public static class MappingProfileConfigureExtension
    {
        public static IServiceCollection AddConfigureMapping(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(options => options.AddProfile(new AutoMappingProfile()));

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }

    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Contact, ContactDVO>()
                .ForMember(x => x.FullName, y => y.MapFrom(z => z.FirstName + " " + z.LastName))
                //.ForMember(x=> x.Id, y => y.MapFrom(z => z.Id))
                .ReverseMap();
        }
    }
}
