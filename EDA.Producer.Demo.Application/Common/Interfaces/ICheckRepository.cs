using EDA.Producer.Demo.Domain.Checks.Entities;

namespace EDA.Producer.Demo.Application.Common.Interfaces;

public interface ICheckRepository
{
    Task AddCheckAsync(Check check);
    Task GenerateCheckAsync(Guid id);
    Task<Check?> GetCheckByIdAsync(Guid id);
    Task UpdateCheckAsync(Check check);
    
    Task<IEnumerable<Check>> GetChecksAsync();
}