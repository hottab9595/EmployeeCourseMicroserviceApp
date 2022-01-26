using AutoMapper;
using EmployeeMicroservice.Services.Models;

namespace EmployeeMicroservice.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, Db.Models.Employee>();
            CreateMap<Db.Models.Employee, Employee>();

            CreateMap<Department, Db.Models.Department>();
            CreateMap<Db.Models.Department, Department>();
        }
    }
}