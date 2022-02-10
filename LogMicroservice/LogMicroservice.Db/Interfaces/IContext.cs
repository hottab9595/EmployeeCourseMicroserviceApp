using EmployeeMicroservice.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace LogMicroservice.Db.Interfaces
{
    public interface IContext
    {
        DbSet<Log> Logs { get; set; }
    }
}