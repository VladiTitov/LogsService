using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;

namespace LogsService.RabbitMQ.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = 0;

            do
            {
                var time = new Random().Next(1000, 3000);
                Thread.Sleep(time);

                var factory = new ConnectionFactory() {HostName = "localhost"};
                using (var connections = factory.CreateConnection())
                using (var channel = connections.CreateModel())
                {
                    channel.QueueDeclare(queue: "logs-queue",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    string message = $"Message from publisher {count++}";

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                        routingKey: "logs-queue",
                        basicProperties: null,
                        body: body);
                }

                Console.WriteLine($"Message from publisher {count}");
            } while (true);
        }
    }
}
