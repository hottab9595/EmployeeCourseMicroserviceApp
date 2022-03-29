using AuthorizationMicroservice.Api.Models;
using AuthorizationMicroservice.Services.Models;
using AuthorizationMicroservice.Services.Models.Service;
using AutoMapper;

namespace AuthorizationMicroservice.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterModel, UserModel>();
            CreateMap<UserModel, RegisterModel>();

            CreateMap<LoginModel, UserModel>();
            CreateMap<UserModel, LoginModel>();
        }
    }
}