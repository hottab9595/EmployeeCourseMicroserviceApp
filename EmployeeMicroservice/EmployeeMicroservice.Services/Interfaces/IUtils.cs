using System.Threading.Tasks;
using EmployeeMicroservice.Services.Models;
using DbEmployee = EmployeeMicroservice.Db.Models.Employee;
using DbDepartment = EmployeeMicroservice.Db.Models.Department;

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
    }
}