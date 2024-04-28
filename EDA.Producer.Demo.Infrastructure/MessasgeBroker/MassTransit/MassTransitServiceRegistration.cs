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
            x.SetKebabCaseEndpointNameFormatter();

            var entryAssembly = Assembly.GetEntryAssembly();
            x.AddActivities(entryAssembly);

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ConfigureEndpoints(context);
            });
        });
        
        return services;
    }
}