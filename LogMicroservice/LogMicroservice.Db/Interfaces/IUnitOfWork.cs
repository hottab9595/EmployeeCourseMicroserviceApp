using System.Threading.Tasks;
using EmployeeMicroservice.Db.Models;

namespace LogMicroservice.Db.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Log> Logs { get; }
        Task SaveAsync();
    }
}