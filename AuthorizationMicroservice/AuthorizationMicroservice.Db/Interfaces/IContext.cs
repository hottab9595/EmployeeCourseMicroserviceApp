using AuthorizationMicroservice.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationMicroservice.Db.Interfaces
{
    public interface IContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
    }
}