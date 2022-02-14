using System.Collections.Generic;
using AuthorizationMicroservice.Db.Interfaces;
using AuthorizationMicroservice.Services.Interfaces;
using AuthorizationMicroservice.Services.Models;
using AutoMapper;

namespace AuthorizationMicroservice.Services.Core
{
    public class AuthorizationService : BaseService, IAuthorizationService
    {
        public AuthorizationService(IUnitOfWork db, IMapper mapper) : base(db)
        {
            this.mapper = mapper;
        }

        private IMapper mapper;


        public IEnumerable<UserModel> GetAllUserModel()
        {
            return mapper.Map<IEnumerable<UserModel>>(db.Users.GetAll());
        }

        public IEnumerable<RoleModel> GetAllRoleModel()
        {
            return mapper.Map<IEnumerable<RoleModel>>(db.Roles.GetAll());
        }

        public IEnumerable<UserRoleModel> GetAllUserRoleModel()
        {
            return mapper.Map<IEnumerable<UserRoleModel>>(db.UserRoles.GetAll());
        }

        public void Authorize(string login, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}