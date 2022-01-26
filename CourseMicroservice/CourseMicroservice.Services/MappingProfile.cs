using AutoMapper;
using CourseMicroservice.Services.Models;
using DbModel = CourseMicroservice.Db.Model;

namespace CourseMicroservice.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, DbModel.Employee>();
            CreateMap<DbModel.Employee, Employee>();

            CreateMap<Course, DbModel.Course>();
            CreateMap<DbModel.Course, Course>();

            CreateMap<Membership, DbModel.CourseEmployee>();
            CreateMap<DbModel.CourseEmployee, Membership>();
        }
    }
}