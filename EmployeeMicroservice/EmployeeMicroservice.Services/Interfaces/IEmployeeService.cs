using EmployeeMicroservice.Services.Models;

namespace EmployeeMicroservice.Services.Interfaces
{
    public interface IEmployeeService<T> : ICoreService, ICrud<T> where T : BaseModel
    {
    }
}