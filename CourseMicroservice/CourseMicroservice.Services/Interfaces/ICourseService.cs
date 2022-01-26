
using CourseMicroservice.Services.Models;

namespace CourseMicroservice.Services.Interfaces
{
    public interface ICourseService<T> : ICoreService, ICrud<T> where T : BaseModel
    {
    }
}