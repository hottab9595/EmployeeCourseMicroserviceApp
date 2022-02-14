using System;
using System.Threading.Tasks;
using AuthorizationMicroservice.Db.Interfaces;
using AuthorizationMicroservice.Db.Models;

namespace AuthorizationMicroservice.Db.Core
{
    public class ContextUnitOfWork : IUnitOfWork
    {
        private Context Db { get; set; }
        private readonly IServiceProvider _serviceProvider;

        public ContextUnitOfWork(Context context, IServiceProvider serviceProvider)
        {
            this.Db = context;
            this._serviceProvider = serviceProvider;
        }

        public IRepository<User> Users => GetRepository<User>();
        public IRepository<Role> Roles => GetRepository<Role>();
        public IRepository<UserRole> UserRoles => GetRepository<UserRole>();

        public async Task SaveAsync() => await Db.SaveChangesAsync();

        private IRepository<T> GetRepository<T>() where T : class
        {
            return (IRepository<T>)_serviceProvider.GetService(typeof(IRepository<T>));
        }
    }
}