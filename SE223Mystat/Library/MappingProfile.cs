using AutoMapper;
using Library.Entities;
using Library.Models;
using Microsoft.AspNetCore.Identity;

namespace Library
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
