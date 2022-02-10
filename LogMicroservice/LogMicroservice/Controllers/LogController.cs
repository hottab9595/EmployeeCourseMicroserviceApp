using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMicroservice.Db.Models;
using LogMicroservice.Db.Interfaces;
using LogMicroservice.Sevices;
using LogMicroservice.Sevices.Interfaces;
using LogMicroservice.Sevices.Models;

namespace LogMicroservice.Api.Controllers
{
    [ApiController]
    [Route("api/Logs")]
    public class LogController : Controller
    {
        public LogController(ILogService logService)
        {
            this.logService = logService;
        }

        private ILogService logService;

        [HttpGet]
        public async Task<IEnumerable<LogModel>> GetLogMessages([FromQuery] DateTime? dateTimeFrom,
                                                                [FromQuery] DateTime? dateTimeTo,
                                                                [FromQuery] int? take,
                                                                [FromQuery] int? skip,
                                                                [FromQuery] Guid? userId,
                                                                [FromQuery] string ipAddress,
                                                                [FromQuery] string operation)
        {
            return await logService.GetLogMessagesAsync(dateTimeFrom, dateTimeTo, take, skip, userId, ipAddress, operation);
        }

        [HttpGet("{id:guid}")]
        public LogModel GetLogMessage(Guid id)
        {
            return logService.GetLogMessage(id);
        }

        [HttpPost]
        public async Task AddLogMessage(LogModel logModel)
        {
            await logService.AddLogMessageAsync(logModel);
        }
    }
}
