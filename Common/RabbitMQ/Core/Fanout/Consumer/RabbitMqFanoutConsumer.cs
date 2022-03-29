using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.RabbitMQ.Core.Common;
using Common.RabbitMQ.Models.Fanout;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Common.RabbitMQ.Core.Fanout.Consumer
{
    public class RabbitMqFanoutConsumer : RabbitMqCoreConsumer
    {
        public RabbitMqFanoutConsumer(IOptions<RabbitMqFanoutConfigurationModel> rabbitMqOptions) : base(rabbitMqOptions)
        {
        }

        private void ReceiveMessage()
        {
            channel.ExchangeDeclare(exchange: rabbitMqConfigurationModel.Exchange, type: ExchangeType.Fanout);

            var queueName = channel.QueueDeclare().QueueName;

            channel.QueueBind(queue: queueName,
                                 exchange: rabbitMqConfigurationModel.Exchange,
                                 routingKey: String.Empty);

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
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            ReceiveMessage();

            return Task.CompletedTask;
        }
    }
}
