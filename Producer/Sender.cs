using System.Text;
using RabbitMQ.Client;

namespace Producer
{
    internal class Sender
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);
                string message = "Test Rabbi MQ";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("","BasicTest",null,body);
                Console.WriteLine("Message Sent {0}",message);


                Console.ReadLine();
            }     
        }
    }
}