using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AuthorizationMicroservice.Services.Interfaces;
using AuthorizationMicroservice.Services.Models;

namespace AuthorizationMicroservice.Api.Controllers
{
    [ApiController]
    [Route("api/Authorization")]
    public class AuthotizationController : Controller
    {
        public AuthotizationController(IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
        }

        private IAuthorizationService authorizationService;

        [HttpGet("{id:int}")]
        public IEnumerable<BaseModel> GetLogMessage(int id)
        {
            switch (id)
            {
                case 1:
                    return authorizationService.GetAllUserModel();
                case 2:
                    return authorizationService.GetAllRoleModel();
                case 3:
                    return authorizationService.GetAllUserRoleModel();
                default:
                    return authorizationService.GetAllUserRoleModel();
            }
        }
    }
}
