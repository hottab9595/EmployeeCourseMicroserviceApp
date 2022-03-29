using System;
using Common.RabbitMQ.Models.Common;
using Common.RabbitMQ.Models.Fanout;

namespace AuthorizationMicroservice.Services.Models.RabbitMQ
{
    public class RabbitMqAuthorizePublishModel : PublishFanoutModel
    {
        public DateTime DateTimeNow => DateTime.Now;

        public string Login { get; set; }
    }
}
