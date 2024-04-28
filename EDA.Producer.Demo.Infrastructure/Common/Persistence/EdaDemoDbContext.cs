using System.Reflection;
using EDA.Producer.Demo.Application.Common.Interfaces;
using EDA.Producer.Demo.Domain.Checks.Entities;
using MassTransit.NewIdFormatters;
using Microsoft.EntityFrameworkCore;

namespace EDA.Producer.Demo.Infrastructure.Common.Persistence;

public class EdaDemoDbContext : DbContext, IUnitOfWork
{
    public DbSet<Check> Checks { get; set; } = null!;

    public EdaDemoDbContext(DbContextOptions options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
    
    public async Task CommitTransactionAsync()
    {
        await SaveChangesAsync();
    }
    
    public async Task RevertTransactionAsync()
    {
        await Database.RollbackTransactionAsync();
    }
    
    

}