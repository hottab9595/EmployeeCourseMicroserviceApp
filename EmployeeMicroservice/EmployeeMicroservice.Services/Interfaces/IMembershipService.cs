using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeMicroservice.Services.Models;

namespace EmployeeMicroservice.Services.Interfaces
{
    public interface IMembershipService<T> : ICoreService where T : BaseModel
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetAsync(int id);
        Task<T> AddNewAsync(int employeeId, int courseId);
        Task DeleteAsync(int id);
    }
}