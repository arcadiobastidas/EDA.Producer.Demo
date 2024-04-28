namespace EDA.Producer.Demo.Worker.Common.Interfaces;

public interface IChecksHub
{
    Task CheckUpdated(Guid checkId);
}