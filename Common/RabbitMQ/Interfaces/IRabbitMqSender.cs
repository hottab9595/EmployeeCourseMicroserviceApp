using Common.RabbitMQ.Models.Common;

namespace Common.RabbitMQ.Interfaces
{
    public interface IRabbitMqSender<T> where T : PublishModel
    {
        void SendMessage(T messageModel);
    }
}