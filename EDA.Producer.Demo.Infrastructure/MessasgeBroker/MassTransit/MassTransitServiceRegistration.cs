using System.Reflection;
using EDA.Producer.Demo.Infrastructure.MessasgeBroker.Configuration;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EDA.Producer.Demo.Infrastructure.MessasgeBroker.MassTransit;

public static class MassTransitServiceRegistration
{
    private static bool? _isRunningInContainer;
    private static bool IsRunningInContainer =>
        _isRunningInContainer ??= 
            bool.TryParse(Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER"),
                out var inContainer) && inContainer;
    
    public static IServiceCollection AddMassTransitServices(this IServiceCollection services, IConfiguration configuration)
    {
        configuration.GetValue<SendEndpoint>("SendEndpoint");
        services.AddMassTransit(x =>
        {
            x.AddDelayedMessageScheduler();

            x.SetKebabCaseEndpointNameFormatter();

            // By default, sagas are in-memory, but should be changed to a durable
            // saga repository.
            x.SetInMemorySagaRepositoryProvider();

            var entryAssembly = Assembly.GetEntryAssembly();

            x.AddConsumers(entryAssembly);
            x.AddSagaStateMachines(entryAssembly);
            x.AddSagas(entryAssembly);
            x.AddActivities(entryAssembly);

            x.UsingRabbitMq((context, cfg) =>
            {
                if (IsRunningInContainer)
                    cfg.Host("rabbitmq");

                cfg.UseDelayedMessageScheduler();

                cfg.ConfigureEndpoints(context);
            });
        });
        
        return services;
    }
}