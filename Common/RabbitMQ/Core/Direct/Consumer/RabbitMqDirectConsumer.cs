using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.RabbitMQ.Core.Common;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Common.RabbitMQ.Models.Direct;

namespace Common.RabbitMQ.Core.Direct.Consumer
{
    public class RabbitMqDirectConsumer : RabbitMqCoreConsumer
    {
        public RabbitMqDirectConsumer(IOptions<RabbitMqDirectConfigurationModel> rabbitMqOptions) : base(rabbitMqOptions)
        {
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            ReceiveMessage();

            return Task.CompletedTask;
        }

        private void ReceiveMessage()
        {
            channel.ExchangeDeclare(exchange: rabbitMqConfigurationModel.Exchange, type: ExchangeType.Direct);

            var queueName = channel.QueueDeclare().QueueName;

            ///todo asjdkj
            channel.QueueBind(queue: queueName,
                exchange: rabbitMqConfigurationModel.Exchange,
                routingKey: "error");
            channel.QueueBind(queue: queueName,
                exchange: rabbitMqConfigurationModel.Exchange,
                routingKey: "info");
            channel.QueueBind(queue: queueName,
                exchange: rabbitMqConfigurationModel.Exchange,
                routingKey: "warning");

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (sender, e) =>
            {
                ReadOnlyMemory<byte> body = e.Body;
                string message = Encoding.UTF8.GetString(body.ToArray());
            };

            consumer.Shutdown += base.OnConsumerShutdown;
            consumer.Registered += base.OnConsumerRegistered;
            consumer.Unregistered += base.OnConsumerUnregistered;
            consumer.ConsumerCancelled += base.OnConsumerCancelled;

            channel.BasicConsume(queue: queueName,
                autoAck: true,
                consumer: consumer);
        }
    }
}
