using AutoMapper;
using cacheHW.Data;
using cacheHW.Dto;

namespace cacheHW.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
        }

    }
}
