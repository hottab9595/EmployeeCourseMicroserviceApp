using CourseMicroservice.Db.Interfaces;
using CourseMicroservice.Services.Models;


namespace CourseMicroservice.Services.Core
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