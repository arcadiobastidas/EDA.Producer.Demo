using EDA.Producer.Demo.Application;
using EDA.Producer.Demo.Infrastructure;
using EDA.Producer.Demo.Worker.Common.Interfaces;
using EDA.Producer.Demo.Worker.Endpoints;
using Microsoft.AspNetCore.Http.Connections;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddTransient<IChecksHub, ChecksHub>();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddApplicationServices();
services.AddInfrastructureServices(configuration);
services.AddSignalR();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapCheckManagementGroup();
app.MapHub<ChecksHub>( "/checksHub", options =>
{
    options.Transports = HttpTransports.All;
    options.ApplicationMaxBufferSize = 1024 * 1024 * 10;
    options.TransportMaxBufferSize = 1024 * 1024 * 10;
    options.LongPolling.PollTimeout = System.TimeSpan.FromMinutes( 1 );
} ).WithDisplayName("Checks Hub");
app.Run();
