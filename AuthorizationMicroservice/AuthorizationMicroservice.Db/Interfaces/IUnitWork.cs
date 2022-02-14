using System.Threading.Tasks;
using AuthorizationMicroservice.Db.Models;

namespace AuthorizationMicroservice.Db.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        IRepository<Role> Roles { get; }
        IRepository<UserRole> UserRoles { get; }
        Task SaveAsync();
    }
}