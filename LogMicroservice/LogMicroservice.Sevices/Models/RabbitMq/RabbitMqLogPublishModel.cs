using Common.RabbitMQ.Models.Fanout;
using System;

namespace LogMicroservice.Sevices.Models.RabbitMq
{
    public class RabbitMqLogPublishModel : PublishFanoutModel
    {
        public DateTime DateTimeNow => DateTime.Now;

        public string Message { get; set; }
    }
}
