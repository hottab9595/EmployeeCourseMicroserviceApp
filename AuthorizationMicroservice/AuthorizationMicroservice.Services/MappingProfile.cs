using AuthorizationMicroservice.Db.Models;
using AuthorizationMicroservice.Services.Models;
using AuthorizationMicroservice.Services.Models.Service;
using AutoMapper;

namespace AuthorizationMicroservice.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();

            CreateMap<Role, RoleModel>();
            CreateMap<RoleModel, Role>();

            CreateMap<UserRole, UserRoleModel>();
            CreateMap<UserRoleModel, UserRole>();
        }
    }
}