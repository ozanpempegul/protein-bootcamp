using AutoMapper;
using LoginHW.Data;
using LoginHW.Dto;

namespace LoginHW.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<Person, PersonDto>().ReverseMap();
        }

    }
}
