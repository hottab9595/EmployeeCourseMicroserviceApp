using CourseMicroservice.Db.Model;
using Microsoft.EntityFrameworkCore;

namespace CourseMicroservice.Db.Interfaces
{
    public interface IContext
    {
        DbSet<Course> Courses { get; set; }
        DbSet<CourseEmployee> CourseEmployees { get; set; }
    }
}