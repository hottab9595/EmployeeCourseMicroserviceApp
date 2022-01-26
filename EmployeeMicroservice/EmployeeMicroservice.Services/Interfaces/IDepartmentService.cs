using EmployeeMicroservice.Services.Models;

namespace EmployeeMicroservice.Services.Interfaces
{
    public interface IDepartmentService<T> : ICoreService, ICrud<T> where T : BaseModel
    {

    }
}