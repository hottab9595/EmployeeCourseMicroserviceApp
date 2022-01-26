using System.Threading.Tasks;
using CourseMicroservice.Services.Interfaces;
using CourseMicroservice.Services.Models;
using Microsoft.AspNetCore.Mvc;


namespace CourseMicroservice.Controllers
{
    [ApiController]
    [Route("api/Courses")]
    public class CourseController : Controller
    {
        public CourseController(ICourseService<Course> cs)
        {
            _cs = cs; 
        }

        private readonly ICourseService<Course> _cs;

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            return Ok(await _cs.GetAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSpecificCourse(int id)
        {
            return Ok(await _cs.GetAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCourse(Course course)
        {
            return Ok(await _cs.AddNewAsync(course));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCourse(int id, Course course)
        {
            return Ok(await _cs.UpdateAsync(id, course));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> FullDeleteCourse(int id)
        {
            await _cs.DeleteAsync(id);
            return Ok();
        }
    }
}