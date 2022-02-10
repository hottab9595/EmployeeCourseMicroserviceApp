using System.Threading.Tasks;
using EmployeeMicroservice.Services.Interfaces;
using EmployeeMicroservice.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMicroservice.Api.Controllers
{
    [ApiController]
    [Route("api/Departments")]
    public class DepartmentController : Controller
    {
        public DepartmentController(IDepartmentService<Department> ds)
        {
            _ds = ds;
        }

        private readonly IDepartmentService<Department> _ds;

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            return Ok(await _ds.GetAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSpecificDepartment(int id)
        {
            return Ok(await _ds.GetAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(Department department)
        {
            return Ok(await _ds.AddNewAsync(department));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateDepartment(int id, Department department)
        {
            return Ok(await _ds.UpdateAsync(id, department));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> FullDeleteDepartment(int id)
        {
            await _ds.DeleteAsync(id);
            return Ok();
        }
    }
}
