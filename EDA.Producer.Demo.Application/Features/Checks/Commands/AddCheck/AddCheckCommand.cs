using EDA.Producer.Demo.Domain.Checks.Entities;
using ErrorOr;
using MediatR;

namespace EDA.Producer.Demo.Application.Features.Checks.Commands.AddCheck;

public record AddCheckCommand (string Name, decimal Amount) : IRequest<ErrorOr<Check>>;
