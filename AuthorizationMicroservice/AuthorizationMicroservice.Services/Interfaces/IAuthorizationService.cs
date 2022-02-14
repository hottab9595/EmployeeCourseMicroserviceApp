using System.Collections.Generic;
using AuthorizationMicroservice.Services.Models;

namespace AuthorizationMicroservice.Services.Interfaces
{
    public interface IAuthorizationService
    {
        IEnumerable<UserModel> GetAllUserModel();
        IEnumerable<RoleModel> GetAllRoleModel();
        IEnumerable<UserRoleModel> GetAllUserRoleModel();
        void Authorize(string login, string password);
    }
}