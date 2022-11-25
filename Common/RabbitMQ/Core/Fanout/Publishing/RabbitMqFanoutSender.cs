using System;
using System.Text;
using Common.RabbitMQ.Core.Common;
using Common.RabbitMQ.Interfaces;
using Common.RabbitMQ.Models.Fanout;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Common.RabbitMQ.Core.Fanout.Publishing
{
    public class RabbitMqFanoutSender<T> : RabbitMqSender, IRabbitMqSender<T> where T : PublishFanoutModel
    {
        public RabbitMqFanoutSender(IOptions<RabbitMqFanoutConfigurationModel> rabbitMqOptions) : base(rabbitMqOptions)
        {
        }

        public void SendMessage(T messageModel)
        {
            channel.ExchangeDeclare(exchange: rabbitMqConfigurationModel.Exchange, type: ExchangeType.Fanout);

            

            var message = JsonConvert.SerializeObject(messageModel);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: rabbitMqConfigurationModel.Exchange,
                routingKey: "",
                basicProperties: null,
                body: body);
        }
    }
}