using System.Threading.Tasks;
using CourseMicroservice.Services.Models;
using DbCourse = CourseMicroservice.Db.Model.Course;
using DbMembership = CourseMicroservice.Db.Model.CourseEmployee;

namespace CourseMicroservice.Services.Interfaces
{
    public interface IUtils
    {
        public Task<(bool isExists, DbCourse course)> IsCourseExistsAsync(int id);

        public Task<(bool isExists, DbCourse course)> IsCourseExistsAsync(Course course);
        public Task<bool> IsCourseNotExistsAsync(int id);

        public Task<bool> IsCourseNotExistsAsync(Course course);

        public Task<(bool isExists, DbMembership membership)> IsMembershipExists(int id);
        public Task<(bool isExists, DbMembership membership)> IsMembershipExists(Membership membership);
        public Task<bool> IsMembershipNotExists(int id);
        public Task<bool> IsMembershipNotExists(Membership membership);
    }
}