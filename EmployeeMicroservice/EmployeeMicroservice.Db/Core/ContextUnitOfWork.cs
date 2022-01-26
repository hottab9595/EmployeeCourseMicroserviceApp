using System;
using System.Threading.Tasks;
using EmployeeMicroservice.Db.Interfaces;
using EmployeeMicroservice.Db.Models;

namespace EmployeeMicroservice.Db.Core
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

        public IRepository<Employee> Employees => GetRepository<Employee>();
        public IRepository<Department> Departments => GetRepository<Department>();

        public async Task SaveAsync() => await Db.SaveChangesAsync();

        private IRepository<T> GetRepository<T>() where T : class
        {
            return (IRepository<T>)_serviceProvider.GetService(typeof(IRepository<T>));
        }
    }
}