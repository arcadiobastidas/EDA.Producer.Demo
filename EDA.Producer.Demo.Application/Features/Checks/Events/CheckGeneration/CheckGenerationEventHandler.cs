using Eda.Demo.Messaging.Contracts.Outbound;
using EDA.Producer.Demo.Application.Common.Interfaces;
using EDA.Producer.Demo.Domain.CheckGeneration.Events;
using MediatR;
using ErrorOr;

namespace EDA.Producer.Demo.Application.Features.Checks.Events.CheckGeneration;

public class CheckGenerationEventHandler : INotificationHandler<GenerateCheck>
{
    private readonly IMessageProducer _messageProducer;
    private readonly ICheckRepository _checkRepository;
    
    public CheckGenerationEventHandler(IMessageProducer messageProducer, ICheckRepository checkRepository)
    {
        _messageProducer = messageProducer;
        _checkRepository = checkRepository;
    }
    
    public async Task Handle(GenerateCheck notification, CancellationToken cancellationToken)
    {
        var check = await _checkRepository.GetCheckByIdAsync(notification.Id);
        var checkToGenerate = check!.CheckIsNotGenerated(check);
        
        if (checkToGenerate.IsError)
        {
          await  Task.FromResult(checkToGenerate.Errors);

        }
        var outboundEvent = new CheckGenerationRequested(check.Id);
        await _messageProducer.SendAsync(outboundEvent, cancellationToken);

    }

}