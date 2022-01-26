using EmployeeMicroservice.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMicroservice.Db.Interfaces
{
    public interface IContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<Department> Departments { get; set; }
    }
}