using System.Text;
using Common.RabbitMQ.Core.Common;
using Common.RabbitMQ.Interfaces;
using Common.RabbitMQ.Models.Direct;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Common.RabbitMQ.Core.Direct.Publishing
{
    public class RabbitMqDirectSender<T> : RabbitMqSender, IRabbitMqSender<T> where T : PublishDirectModel
    {
        public RabbitMqDirectSender(IOptions<RabbitMqDirectConfigurationModel> rabbitMqOptions) : base(rabbitMqOptions)
        {
        }

        public void SendMessage(T messageModel)
        {
            channel.ExchangeDeclare(exchange: rabbitMqConfigurationModel.Exchange, type: ExchangeType.Direct);

            var message = JsonConvert.SerializeObject(messageModel);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: rabbitMqConfigurationModel.Exchange,
                routingKey: "",
                basicProperties: null,
                body: body);
        }
    }
}