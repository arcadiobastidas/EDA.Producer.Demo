namespace EDA.Producer.Demo.Application.Common.Interfaces;

public interface IUnitOfWork
{
    public Task CommitTransactionAsync();
    public Task RevertTransactionAsync();
}