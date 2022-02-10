using System;
using System.Threading.Tasks;
using EmployeeMicroservice.Db;
using EmployeeMicroservice.Db.Models;
using LogMicroservice.Db.Interfaces;

namespace LogMicroservice.Db.Core
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

        public IRepository<Log> Logs => GetRepository<Log>();

        public async Task SaveAsync() => await Db.SaveChangesAsync();

        private IRepository<T> GetRepository<T>() where T : class
        {
            return (IRepository<T>)_serviceProvider.GetService(typeof(IRepository<T>));
        }
    }
}