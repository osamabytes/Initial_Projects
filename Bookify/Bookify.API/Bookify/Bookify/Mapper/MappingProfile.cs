using AutoMapper;
using Bookify.Dto;
using Bookify.Models;

namespace Bookify.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationDto, User>()
                .ForMember(user => user.Id, option => option.MapFrom(user => user.Id))
                .ForMember(user => user.FirstName, option => option.MapFrom(user => user.FirstName))
                .ForMember(user => user.LastName, option => option.MapFrom(user => user.LastName))
                .ForMember(user => user.UserName, option => option.MapFrom(user => user.Email))
                .ForMember(user => user.Email, option => option.MapFrom(user => user.Email));
        }
    }
}
