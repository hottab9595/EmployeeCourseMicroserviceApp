using AutoMapper;
using EmployeeMicroservice.Services.Models;
using DbModel = EmployeeMicroservice.Db.Models;

namespace EmployeeMicroservice.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, DbModel.Employee>();
            CreateMap<DbModel.Employee, Employee>();

            CreateMap<Department, DbModel.Department>();
            CreateMap<DbModel.Department, Department>();

            CreateMap<Course, DbModel.Course>();
            CreateMap<DbModel.Course, Course>();

            CreateMap<Membership, DbModel.CourseEmployee>();
            CreateMap<DbModel.CourseEmployee, Membership>();
        }
    }
}