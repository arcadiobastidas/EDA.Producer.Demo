using EDA.Producer.Demo.Application.Common.Interfaces;
using EDA.Producer.Demo.Domain.Checks.Entities;
using EDA.Producer.Demo.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EDA.Producer.Demo.Infrastructure.Checks.Persistence;

public class CheckRepository : ICheckRepository
{
    private readonly ILogger<CheckRepository> _logger;
    private readonly EdaDemoDbContext _context;
    
    public CheckRepository(ILogger<CheckRepository> logger, EdaDemoDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    public Task AddCheckAsync(Check check)
    {
        _logger.LogInformation("Adding check with name {Name} and amount {Amount}", check.Name, check.Amount);
        _context.Checks.Add(check);
        return Task.CompletedTask;
    }
    
    public Task GenerateCheckAsync(Guid id)
    {
        var check = _context.Checks.Find(id);
        check!.Generate();
        return Task.CompletedTask;
    }
    
    public async Task<Check?> GetCheckByIdAsync(Guid id)
    {
        var check = _context.Checks.FindAsync(id);
        return await check;
    }
    
    public Task UpdateCheckAsync(Check check)
    {
        _logger.LogInformation("Updating check with id {Id}", check.Id);
        _context.Checks.Update(check);
        return Task.CompletedTask;
    }
    
    public async Task<IEnumerable<Check>> GetChecksAsync()
    {
        return await _context.Checks.ToListAsync();
    }


}