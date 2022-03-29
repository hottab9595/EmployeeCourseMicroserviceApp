using Common.RabbitMQ.Models.Common;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Common.RabbitMQ.Core.Common
{
    public abstract class RabbitMqCore 
    {
        protected readonly RabbitMqConfigurationModel rabbitMqConfigurationModel;
        protected IConnection connection;
        protected IModel channel;
        
        protected RabbitMqCore(IOptions<RabbitMqConfigurationModel> rabbitMqOptions)
        {
            rabbitMqConfigurationModel = rabbitMqOptions.Value;

            ConnectionFactory factory = new ConnectionFactory
            {
                HostName = rabbitMqConfigurationModel.HostName,
                UserName = rabbitMqConfigurationModel.UserName,
                Password = rabbitMqConfigurationModel.Password
            };

            connection = factory.CreateConnection();
            channel = connection.CreateModel();
        }
    }
}