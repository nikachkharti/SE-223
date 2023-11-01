using AutoMapper;
using Library.Models;
using Microsoft.AspNetCore.Identity;

namespace Library.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationModel, IdentityUser>()
                .ForMember(x => x.UserName, options => options.MapFrom(x => x.Email));
        }
    }
}
