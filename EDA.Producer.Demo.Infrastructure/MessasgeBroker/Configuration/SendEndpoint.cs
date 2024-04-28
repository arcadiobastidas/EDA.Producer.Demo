using Microsoft.Extensions.Configuration;

namespace EDA.Producer.Demo.Infrastructure.MessasgeBroker.Configuration;

public class SendEndpoint
{
    public string QueueName { get; set; } = string.Empty;
}