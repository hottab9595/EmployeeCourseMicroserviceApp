namespace Common.RabbitMQ.Models.Common
{
    public abstract class RabbitMqConfigurationModel
    {
        public string HostName { get; set; } = Constants.RabbitMqQ.Constants.HOSTNAME;

        public string Exchange { get; set; } = Constants.RabbitMqQ.Constants.EXCHANGE;

        public string QueueName { get; set; }

        public string UserName { get; set; } = Constants.RabbitMqQ.Constants.USERNAME;

        public string Password { get; set; } = Constants.RabbitMqQ.Constants.PASSWORD;

        public bool Enabled { get; set; } = Constants.RabbitMqQ.Constants.ENABLED;
    }
}