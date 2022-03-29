using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorizationMicroservice.Services.Models;
using AuthorizationMicroservice.Services.Models.Service;

namespace AuthorizationMicroservice.Services.Interfaces
{
    public interface IAuthorizationService
    {
        Task<UserModel> RegisterNewUserAsync(UserModel userModel);
        UserModel Authorize(UserModel userModel);
        void RefreshToken();
    }
}