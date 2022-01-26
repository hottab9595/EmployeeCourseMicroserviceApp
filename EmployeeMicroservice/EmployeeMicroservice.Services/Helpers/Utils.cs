using System.Threading.Tasks;
using Common.Exceptions;
using EmployeeMicroservice.Db.Interfaces;
using EmployeeMicroservice.Services.Interfaces;
using EmployeeMicroservice.Services.Models;
using Microsoft.EntityFrameworkCore;
using DbEmployee = EmployeeMicroservice.Db.Models.Employee;
using DbDepartment = EmployeeMicroservice.Db.Models.Department;

namespace EmployeeMicroservice.Services.Helpers
{
    public class Utils : IUtils
    {
        public Utils(IUnitOfWork db)
        {
            _db = db;
        }

        private readonly IUnitOfWork _db;

        #region Exists

        public async Task<(bool isExists, DbEmployee employee)> IsEmployeeExistsAsync(int id)
        {
            DbEmployee dbEmployee = await _db.Employees.FindBy(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();

            return dbEmployee != null ? (true, dbEmployee) : throw new EmployeeNotFoundException();
        }

        public async Task<(bool isExists, DbEmployee employee)> IsEmployeeExistsAsync(Employee employee)
        {
            return await IsEmployeeExistsAsync(employee.Id);
        }

        public async Task<(bool isExists, DbDepartment department)> IsDepartmentExistsAsync(int id)
        {
            DbDepartment dbDepartment = await _db.Departments.FindBy(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();

            return dbDepartment != null ? (true, dbDepartment) : throw new DepartmentNotFoundException();
        }

        public async Task<(bool isExists, DbDepartment department)> IsDepartmentExistsAsync(Department department)
        {
            return await IsDepartmentExistsAsync(department.Id);
        }

        #endregion

        #region NotExists

        public async Task<bool> IsEmployeeNotExistsAsync(int id)
        {
            DbEmployee dbEmployee = await _db.Employees.FindBy(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();

            return dbEmployee == null ? true : throw new EmployeeAlreadyExistsException();
        }

        public async Task<bool> IsEmployeeNotExistsAsync(Employee employee)
        {
            return await IsEmployeeNotExistsAsync(employee.Id);
        }

        public async Task<bool> IsDepartmentNotExistsAsync(int id)
        {
            DbEmployee dbEmployee = await _db.Employees.FindBy(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();

            return dbEmployee == null ? true : throw new DepartmentAlreadyExistsException();
        }

        public async Task<bool> IsDepartmentNotExistsAsync(Department department)
        {
            return await IsDepartmentNotExistsAsync(department.Id);
        }

        #endregion
    }
}