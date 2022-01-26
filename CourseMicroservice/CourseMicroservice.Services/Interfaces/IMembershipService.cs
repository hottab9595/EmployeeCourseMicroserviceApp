using System.Collections.Generic;
using System.Threading.Tasks;
using CourseMicroservice.Services.Models;

namespace CourseMicroservice.Services.Interfaces
{
    public interface IMembershipService<T> : ICoreService where T : BaseModel
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetAsync(int id);
        Task<T> AddNewAsync(T t);
        Task DeleteAsync(int id);
    }
}