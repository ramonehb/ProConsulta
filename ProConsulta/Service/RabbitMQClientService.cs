using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace ProConsulta.Service;

public class RabbitMQClientService : IBusService
{
    const string exchange = "notification-service";
    private readonly IModel _channel;

    public RabbitMQClientService()
    {
        var connectionFactory = new ConnectionFactory
        {
            HostName = "localhost"
        };

        var connection = connectionFactory.CreateConnection("ProConsulta.BlazorWebApp");

        _channel = connection.CreateModel();
    }

    public void Publish<T>(string routingKey, T message)
    {
        var contentString = JsonSerializer.Serialize(message);
        var contentByteArray = Encoding.UTF8.GetBytes(contentString);

        _channel.BasicPublish(exchange, routingKey, null, contentByteArray);

        Console.WriteLine($"Messagem publicado no RabbitMQ: {contentString}");
    }
}

