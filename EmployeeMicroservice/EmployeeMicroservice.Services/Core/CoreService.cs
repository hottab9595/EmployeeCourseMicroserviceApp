using EmployeeMicroservice.Db.Interfaces;
using EmployeeMicroservice.Services.Models;

namespace EmployeeMicroservice.Services.Core
{
    public abstract class CoreService<T> where T : BaseModel
    {
        protected IUnitOfWork _db;
        public CoreService(IUnitOfWork db)
        {
            _db = db;
        }
    }
}