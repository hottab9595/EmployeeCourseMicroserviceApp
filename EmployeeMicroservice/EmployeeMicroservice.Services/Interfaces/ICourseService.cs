using EmployeeMicroservice.Services.Models;

namespace EmployeeMicroservice.Services.Interfaces
{
    public interface ICourseService<T> : ICoreService, ICrud<T> where T : BaseModel
    {
    }
}