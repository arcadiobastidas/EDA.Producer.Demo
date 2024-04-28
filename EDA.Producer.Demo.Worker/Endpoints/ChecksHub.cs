using EDA.Producer.Demo.Domain.Checks.Entities;
using EDA.Producer.Demo.Worker.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace EDA.Producer.Demo.Worker.Endpoints;

public class ChecksHub : Hub, IChecksHub
{
    private readonly IMediator _mediator;
    
    public async Task CheckUpdated(Guid checkId)
    {
        await Clients.All.SendAsync("ReceiveCheck", checkId);
    }
}
