using Common.RabbitMQ.Models.Common;
using Microsoft.Extensions.Options;

namespace Common.RabbitMQ.Core.Common
{
    public abstract class RabbitMqSender : RabbitMqCore
    {
        protected RabbitMqSender(IOptions<RabbitMqConfigurationModel> rabbitMqOptions) : base(rabbitMqOptions)
        {
        }
    }
}