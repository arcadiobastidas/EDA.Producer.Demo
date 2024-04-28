using EDA.Producer.Demo.Domain.Checks.Entities;
using MediatR;

namespace EDA.Producer.Demo.Application.Features.Checks.Queries.GetChecks;

public class GetChecksQuery : IRequest<IEnumerable<Check>>
{
    public IEnumerable<Check> Checks { get; set; } = new List<Check>();
}