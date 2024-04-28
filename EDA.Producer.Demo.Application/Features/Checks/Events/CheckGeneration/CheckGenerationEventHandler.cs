using Eda.Demo.Messaging.Contracts.Outbound;
using EDA.Producer.Demo.Application.Common.Interfaces;
using EDA.Producer.Demo.Domain.CheckGeneration.Events;
using MediatR;
using ErrorOr;

namespace EDA.Producer.Demo.Application.Features.Checks.Events.CheckGeneration;

public class CheckGenerationEventHandler : INotificationHandler<GenerateCheck>
{
    private readonly IMessageProducer _messageProducer;

    public CheckGenerationEventHandler(IMessageProducer messageProducer)
    {
        _messageProducer = messageProducer;
    }
    
    public async Task Handle(GenerateCheck notification, CancellationToken cancellationToken)
    {
        var outboundEvent = new CheckGenerationRequested(notification.Id);
        await _messageProducer.SendAsync(outboundEvent, cancellationToken);

    }

}