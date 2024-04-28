using EDA.Producer.Demo.Application.Features.Checks.Commands.AddCheck;
using EDA.Producer.Demo.Application.Features.Checks.Commands.UpdateCheck;
using EDA.Producer.Demo.Application.Features.Checks.Queries.GetChecks;
using EDA.Producer.Demo.Domain.CheckGeneration.Events;
using MediatR;

namespace EDA.Producer.Demo.Worker.Endpoints;

public static class CheckManagementGroup
{
    public static void MapCheckManagementGroup(this IEndpointRouteBuilder endpoints)
    {
  
        // Add a check to the payment system
        endpoints.MapPost("/check", async (AddCheckCommand command, IMediator mediator) =>
        {
            var result = await mediator.Send(new AddCheckCommand(command.Name, command.Amount));
            return Results.Ok(result);

        }).WithOpenApi(cfg =>
        {
            cfg.Description = "Add a check to the payment system";
            return cfg;
        });
        
        // Generate a check in the payment system
        endpoints.MapPost(pattern:"/check/{id}/generate",  (Guid id, IMediator mediator) =>
            {
                var request = mediator.Publish(new GenerateCheck(id));
                return Results.Ok();
            })
            .WithName("Generate a check")
            .WithOpenApi(cfg =>
            {
                cfg.Description = "Flag a check as generated in the payment system";
                return cfg;
            });

        // Get all checks in the payment system
        endpoints.MapGet("/checks", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetChecksQuery());
            return Results.Ok(result);
        }).WithOpenApi(cfg =>
        {
            cfg.Description = "Get all checks in the payment system";
            return cfg;
        });

        // Update the amount of a check in the payment system
        endpoints.MapPatch(pattern:"/check/{id}/amount", async (Guid id, decimal amount, IMediator mediator) =>
            {
                var result = await mediator.Send(new UpdateCheckCommand(id, amount));
                return Results.Ok(result);
            }).WithName("Update the amount of a check")
            .WithOpenApi(cfg =>
            {
                cfg.Description = "Update the amount of a check in the payment system";
                return cfg;
            });
    }
}