using EDA.Producer.Demo.Application.Common.Interfaces;
using EDA.Producer.Demo.Domain.Checks.Entities;
using ErrorOr;
using MediatR;

namespace EDA.Producer.Demo.Application.Features.Checks.Commands.UpdateCheck;

public class UpdateCheckCommandHandler : IRequestHandler<UpdateCheckCommand, ErrorOr<Check>>
{
    private readonly ICheckRepository _checkRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public UpdateCheckCommandHandler(ICheckRepository checkRepository, IUnitOfWork unitOfWork)
    {
        _checkRepository = checkRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Check>> Handle(UpdateCheckCommand request, CancellationToken cancellationToken)
    {
        var check = await _checkRepository.GetCheckByIdAsync(request.Id);
        if (check == null)
        {
            return Error.NotFound(description: "Check not found");
        }
        var updatedCheck = check.UpdateAmount(request.Amount);
       
        if (updatedCheck.IsError)
        {
           return updatedCheck.Errors;
        }
        
        await _checkRepository.UpdateCheckAsync(check);
        await _unitOfWork.CommitTransactionAsync();
        return check;
    }
    
}