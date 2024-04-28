using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace EDA.Producer.Demo.Infrastructure.Common.Persistence;

public static class PersistenceServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("EdaDemoDb:ConnectionString");
        var password = configuration["EdaDemoDb:Password"];
        var username = configuration["EdaDemoDb:Username"];
        var host = configuration["EdaDemoDb:Host"];
        var port = Int32.Parse(configuration["EdaDemoDb:Port"] ?? "5432");
        var dbBuilder = new NpgsqlConnectionStringBuilder(connectionString)
        {
            Username = username,
            Password = password,
            Host = host,
            Port = port
        };
        services.AddDbContext<EdaDemoDbContext>(options =>
        {
            options.UseNpgsql(dbBuilder.ConnectionString);
        });
        
    }
}