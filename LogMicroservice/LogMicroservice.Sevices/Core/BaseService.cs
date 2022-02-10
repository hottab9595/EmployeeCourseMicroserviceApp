using LogMicroservice.Db.Interfaces;

namespace LogMicroservice.Sevices.Core
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