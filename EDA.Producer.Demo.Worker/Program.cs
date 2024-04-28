using EDA.Producer.Demo.Application;
using EDA.Producer.Demo.Application.Features.Checks.Commands.AddCheck;
using EDA.Producer.Demo.Infrastructure;
using EDA.Producer.Demo.Worker.Endpoints;
using MediatR;
using Microsoft.Azure.Amqp.Serialization;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddApplicationServices();
services.AddInfrastructureServices(configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapCheckManagementGroup();
app.Run();
