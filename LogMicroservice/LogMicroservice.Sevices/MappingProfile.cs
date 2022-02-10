using AutoMapper;
using EmployeeMicroservice.Db.Models;
using LogMicroservice.Sevices.Models;

namespace LogMicroservice.Sevices
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Log, LogModel>();
            CreateMap<LogModel, Log>();
        }
    }
}