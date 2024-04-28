using EDA.Producer.Demo.Application.Common.Interfaces;
using EDA.Producer.Demo.Domain.Checks.Entities;
using MediatR;

namespace EDA.Producer.Demo.Application.Features.Checks.Queries.GetChecks;

public class GetChecksQueryHandler : IRequestHandler<GetChecksQuery, IEnumerable<Check>>
{
    private readonly ICheckRepository _checkRepository;
    
    public GetChecksQueryHandler(ICheckRepository checkRepository)
    {
        _checkRepository = checkRepository;
    }
    
    public async Task<IEnumerable<Check>> Handle(GetChecksQuery request, CancellationToken cancellationToken)
    {
        return await _checkRepository.GetChecksAsync();
    }
    
}