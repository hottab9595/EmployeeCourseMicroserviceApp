using System.Threading.Tasks;
using EmployeeMicroservice.Services.Models;
using DbEmployee = EmployeeMicroservice.Db.Models.Employee;
using DbDepartment = EmployeeMicroservice.Db.Models.Department;
using DbCourse = EmployeeMicroservice.Db.Models.Course;
using DbMembership = EmployeeMicroservice.Db.Models.CourseEmployee;

namespace EmployeeMicroservice.Services.Interfaces
{
    public interface IUtils
    {
        public Task<(bool isExists, DbEmployee employee)> IsEmployeeExistsAsync(int id);

        public Task<(bool isExists, DbEmployee employee)> IsEmployeeExistsAsync(Employee employee);

        public Task<bool> IsEmployeeNotExistsAsync(int id);

        public Task<bool> IsEmployeeNotExistsAsync(Employee employee);

        public Task<(bool isExists, DbDepartment department)> IsDepartmentExistsAsync(int id);

        public Task<(bool isExists, DbDepartment department)> IsDepartmentExistsAsync(Department department);
        public Task<bool> IsDepartmentNotExistsAsync(int id);

        public Task<bool> IsDepartmentNotExistsAsync(Department department);

        public Task<(bool isExists, DbCourse course)> IsCourseExistsAsync(int id);

        public Task<(bool isExists, DbCourse course)> IsCourseExistsAsync(Course course);
        public Task<bool> IsCourseNotExistsAsync(int id);

        public Task<bool> IsCourseNotExistsAsync(Course course);

        public Task<(bool isExists, DbMembership membership)> IsMembershipExists(int id);
        public Task<(bool isExists, DbMembership membership)> IsMembershipExists(Membership membership);
        public Task<bool> IsMembershipNotExists(int id);
        public Task<bool> IsMembershipNotExists(int employeeId, int courseId);
    }
}