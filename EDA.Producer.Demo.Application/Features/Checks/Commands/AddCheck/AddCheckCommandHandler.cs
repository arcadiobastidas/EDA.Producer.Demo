using EDA.Producer.Demo.Application.Common.Interfaces;
using EDA.Producer.Demo.Domain.Checks.Entities;
using ErrorOr;
using MediatR;

namespace EDA.Producer.Demo.Application.Features.Checks.Commands.AddCheck;

public class AddCheckCommandHandler : IRequestHandler<AddCheckCommand, ErrorOr<Check>>
{
    private readonly ICheckRepository _checkRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public AddCheckCommandHandler(ICheckRepository checkRepository, IUnitOfWork unitOfWork)
    {
        _checkRepository = checkRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Check>> Handle(AddCheckCommand request, CancellationToken cancellationToken)
    {
        var check = new Check(
            name: request.Name,
            amount: request.Amount);
        
        var checkOrError = check.WithNonNegativeAmount();
        if (checkOrError.IsError)
        {
            return checkOrError.Errors;
        }
        
        await _checkRepository.AddCheckAsync(check);
        await _unitOfWork.CommitTransactionAsync();
        return check;
    }
    
}