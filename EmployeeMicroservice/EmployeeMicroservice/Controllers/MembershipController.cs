using System.Collections.Generic;
using EmployeeMicroservice.Services.Interfaces;
using EmployeeMicroservice.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeMicroservice.Controllers
{
    [ApiController]
    [Route("api/Memberships")]
    public class MembershipController : Controller
    {
        public MembershipController(IMembershipService<Membership> ms)
        {
            _ms = ms;
        }

        private readonly IMembershipService<Membership> _ms;

        [HttpGet]
        public async Task<IActionResult> GetMemberships()
        {
            return Ok(await _ms.GetAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSpecificMembership(int id)
        {
            return Ok(await _ms.GetAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewMembership([FromQuery] int employeeId, [FromQuery] int courseId)
        {
            return Ok(await _ms.AddNewAsync(employeeId, courseId));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> FullDeleteMembership(int id)
        {
            await _ms.DeleteAsync(id);
            return Ok();
        }
    }
}
