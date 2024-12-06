
using NotificationService.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.Json;

namespace NotificationService.Subscribers;

public class NotificationAgendamentoSubscriber : IHostedService
{
    private readonly IModel _channel;

    const string queue = "notification-agendamento-created";

    public NotificationAgendamentoSubscriber()
    {
        var connectionFactory = new ConnectionFactory
        {
            HostName = "localhost"
        };

        var connection = connectionFactory.CreateConnection("NotificationService.API");

        _channel = connection.CreateModel();
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += async (sender, eventArgs) =>
        {
            var contentArray = eventArgs.Body.ToArray();
            var contentString = Encoding.UTF8.GetString(contentArray);

            var @event = JsonSerializer.Deserialize<Agendamento>(contentString);

            DisparaEmail(@event.Observacao, @event.DataConsulta, @event.HoraConsulta);

            _channel.BasicAck(eventArgs.DeliveryTag, false);
        };

        _channel.BasicConsume(queue, false, consumer);

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    //Temporario dentro dessa classe
    public void DisparaEmail(string emailRemetente, DateTime data, TimeSpan horario)
    {
        try
        {
            var smtpClient = new SmtpClient("smtp.gmail.com") 
            {
                Port = 587, 
                Credentials = new NetworkCredential("atendimento@proconsulta.com.br", "18238741345"), 
                EnableSsl = true 
            };

            // Configuração do e-mail
            var mailMessage = new MailMessage
            {
                From = new MailAddress("atendimento@proconsulta.com.br", "Atendimento ProConsulta"),
                Subject = "Agendamento realizado com sucesso.", 
                Body = $"Sua consulta foi agendada para dia {data:dd/MM/yyyy} as {horario} horas",
                IsBodyHtml = false 
            };

            mailMessage.To.Add(emailRemetente); 

            smtpClient.Send(mailMessage);
            Console.WriteLine("E-mail enviado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.StackTrace}");
        }
    }
}

