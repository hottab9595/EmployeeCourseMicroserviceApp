using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeMicroservice.Db.Models;
using LogMicroservice.Db.Interfaces;
using LogMicroservice.Sevices.Interfaces;
using LogMicroservice.Sevices.Models;

namespace LogMicroservice.Sevices.Core
{
    public class LogService : BaseService, ILogService
    {
        public LogService(IUnitOfWork db, IMapper mapper) : base(db)
        {
            this.mapper = mapper;
        }

        private IMapper mapper;

        public async Task<IEnumerable<LogModel>> GetLogMessagesAsync(DateTime? dateTimeFrom, 
                                                                    DateTime? dateTimeTo, 
                                                                    int? take, 
                                                                    int? skip, 
                                                                    Guid? userId,
                                                                    string ipAddress,  
                                                                    string operation)
        {
            IQueryable<Log> query = db.Logs.GetAll();

            #region Request filters

            if (userId.HasValue)
            {
                query = query.Where(log => log.UserId == userId);
            }

            if (!string.IsNullOrEmpty(ipAddress))
            {
                query = query.Where(log => log.IpAddress == ipAddress);
            }

            if (!string.IsNullOrEmpty(operation))
            {
                query = query.Where(log => log.Operation == operation);
            }

            if (dateTimeFrom.HasValue && dateTimeTo.HasValue)
            {
                query = query.Where(log => log.CurrentDateTime >= dateTimeFrom && log.CurrentDateTime <= dateTimeTo);
            }

            if (skip.HasValue)
            {
                query = query.Skip((int)skip);
            }

            if (take.HasValue)
            {
                query = query.Take((int)take);
            }

            #endregion

            return await Task.Run(() => mapper.Map<IEnumerable<LogModel>>(query));
        }

        public LogModel GetLogMessage(Guid id)
        {
            return mapper.Map<LogModel>(db.Logs.Get(id));
        }

        public async Task AddLogMessageAsync(LogModel logModel)
        {
            db.Logs.Add(mapper.Map<Log>(logModel));

            await db.SaveAsync();
        }
    }
}