using System.Threading.Tasks;
using EmployeeMicroservice.Services.Interfaces;
using EmployeeMicroservice.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMicroservice.Controllers
{
    [ApiController]
    [Route("api/Employees")]
    public class EmployeeController : Controller
    {
        public EmployeeController(IEmployeeService<Employee> es)
        {
            _es = es;
        }

        private readonly IEmployeeService<Employee> _es;

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await _es.GetAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSpecificEmployee(int id)
        {
            return Ok(await _es.GetAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEmployee(Employee employee)
        {
            return Ok(employee);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            return Ok(await _es.UpdateAsync(id, employee));
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> FullDeleteEmployee(int id)
        {
            await _es.DeleteAsync(id);
            return Ok();
        }
    }
}
