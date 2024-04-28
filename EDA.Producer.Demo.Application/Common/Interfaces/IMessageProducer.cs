namespace EDA.Producer.Demo.Application.Common.Interfaces;

public interface IMessageProducer
{
    public Task PublishAsync<T>(T message, CancellationToken cancellationToken) where T : class;
    public Task SendAsync<T>(T message, CancellationToken cancellationToken) where T : class;
}