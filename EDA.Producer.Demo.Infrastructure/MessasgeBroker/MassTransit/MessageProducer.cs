using EDA.Producer.Demo.Application.Common.Interfaces;
using EDA.Producer.Demo.Infrastructure.MessasgeBroker.Configuration;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace EDA.Producer.Demo.Infrastructure.MessasgeBroker.MassTransit;

public class MessageProducer : IMessageProducer
{
    private readonly IBus _bus;
    private readonly ILogger<MessageProducer> _logger;

    public MessageProducer(IBus bus, ILogger<MessageProducer> logger)
    {
        _bus = bus;
        _logger = logger;
    }
    
    public async Task PublishAsync<T>(T message, CancellationToken cancellationToken) where T : class
    {
        try
        {
            await _bus.Publish(message, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error publishing message");
            throw;
        }
    }
    
    public async Task SendAsync<T>(T message, CancellationToken cancellationToken) where T : class
    {
        try
        {
            _logger.LogInformation("Sending message: {Message}", message);
            var sendEndpoint = await _bus.GetSendEndpoint(new Uri("queue:eda-demo"));
            await sendEndpoint.Send(message, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending message");
            throw;
        }
    }

}