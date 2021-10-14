using Eagle.Application.Interfaces;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Eagle.Application.Services
{
    public class EagleMessageQueueService : IEagleMessageQueueService
    {
        private readonly ConnectionFactory factory;

        public EagleMessageQueueService()
        {
            factory = new ConnectionFactory
            {
                HostName = "localhost",
            };
        }
        public void SendMessage(string messageBody)
        {
             
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "Save Data", type: "topic");
                    var body = Encoding.UTF8.GetBytes(messageBody);
                    channel.BasicPublish(exchange: "Save Data",
                                    routingKey: "Save Data",
                                    basicProperties: null,
                                    body: body);

                }
            }

        }
    }
}
