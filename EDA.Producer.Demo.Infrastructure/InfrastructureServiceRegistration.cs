using EDA.Producer.Demo.Application.Common.Interfaces;
using EDA.Producer.Demo.Infrastructure.Checks.Persistence;
using EDA.Producer.Demo.Infrastructure.Common.Persistence;
using EDA.Producer.Demo.Infrastructure.MessasgeBroker.MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EDA.Producer.Demo.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistenceServices(configuration);
        services.AddAdditionalServices();
        services.AddMassTransitServices(configuration);
    }
    
    public static void AddAdditionalServices(this IServiceCollection services)
    {
        services.AddTransient<ICheckRepository, CheckRepository>();
        services.AddTransient<IMessageProducer, MessageProducer>();
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<EdaDemoDbContext>());
    }
    
}