using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LogMicroservice.Sevices.Models;

namespace LogMicroservice.Sevices.Interfaces
{
    public interface ILogService
    {
        Task<IEnumerable<LogModel>> GetLogMessagesAsync(DateTime? dateTimeFrom, DateTime? dateTimeTo, int? take, int? skip, Guid? userId, string ipAddress, string operation);
        LogModel GetLogMessage(Guid id);
        Task AddLogMessageAsync(LogModel logModel);
    }
}