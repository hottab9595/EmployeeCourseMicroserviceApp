using AuthorizationMicroservice.Db.Interfaces;

namespace AuthorizationMicroservice.Services.Core
{
    public class BaseService
    {
        public BaseService(IUnitOfWork db)
        {
            this.db = db;
        }

        public IUnitOfWork db;
    }
}