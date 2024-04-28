using EDA.Producer.Demo.Domain.Checks.Entities;
using ErrorOr;
using MediatR;

namespace EDA.Producer.Demo.Application.Features.Checks.Commands.UpdateCheck;

public record UpdateCheckCommand(Guid Id, decimal Amount) : IRequest<ErrorOr<Check>>;