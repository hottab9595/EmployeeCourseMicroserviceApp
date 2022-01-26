using System.Threading.Tasks;
using CourseMicroservice.Db.Model;

namespace CourseMicroservice.Db.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Course> Courses { get; }
        IRepository<CourseEmployee> CourseEmployees { get; }
        Task SaveAsync();
    }
}