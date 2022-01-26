using System.Threading.Tasks;
using EmployeeMicroservice.Db.Models;

namespace EmployeeMicroservice.Db.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Employee> Employees { get; }
        IRepository<Department> Departments { get; }

        Task SaveAsync();
    }
}