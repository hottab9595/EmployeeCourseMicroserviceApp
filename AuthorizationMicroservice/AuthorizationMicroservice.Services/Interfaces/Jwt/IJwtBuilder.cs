using System;
using System.Security.Claims;
using AuthorizationMicroservice.Services.Models;
using AuthorizationMicroservice.Services.Models.Service;

namespace AuthorizationMicroservice.Services.Interfaces.Jwt
{
    public interface IJwtBuilder
    {
        string GetAccessToken(UserModel userModel);
        Guid ValidateToken(string token);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}