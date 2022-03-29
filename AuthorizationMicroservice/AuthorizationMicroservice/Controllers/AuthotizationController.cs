using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorizationMicroservice.Api.Models;
using AuthorizationMicroservice.Services.Interfaces;
using AuthorizationMicroservice.Services.Models;
using AuthorizationMicroservice.Services.Models.Service;
using AutoMapper;

namespace AuthorizationMicroservice.Api.Controllers
{
    [ApiController]
    [Route("api/Authorization")]
    public class AuthotizationController : Controller
    {
        public AuthotizationController(IAuthorizationService authorizationService, IMapper mapper)
        {
            this.authorizationService = authorizationService;
            this.mapper = mapper;
        }

        private IAuthorizationService authorizationService;
        private IMapper mapper;

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterModel registerModel)
        {
            return Ok(mapper.Map<RegisterModel>(await authorizationService.RegisterNewUserAsync(mapper.Map<UserModel>(registerModel))));
        }

        [HttpPost("Authorize")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            return Ok(mapper.Map<LoginModel>(authorizationService.Authorize(mapper.Map<UserModel>(loginModel))));
        }
    }
}
