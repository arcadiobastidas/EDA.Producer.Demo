using Eda.Demo.Messaging.Contracts.Inbound;
using EDA.Producer.Demo.Worker.Common.Interfaces;
using MassTransit;
using MediatR;

namespace EDA.Producer.Demo.Worker.Consumers;

public class MessageConsumer : IConsumer<CheckGenerationCompleted>
{
    private readonly IChecksHub _checksHub;

    public MessageConsumer(IChecksHub checksHub)
    {
        _checksHub = checksHub;
    }
    
    public Task Consume(ConsumeContext<CheckGenerationCompleted> context)
    {
        var checkId = context.Message.Id;
        _checksHub.CheckUpdated(checkId);
        return Task.CompletedTask;
    }
}