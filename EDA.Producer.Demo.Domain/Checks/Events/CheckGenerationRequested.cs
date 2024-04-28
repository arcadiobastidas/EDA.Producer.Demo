using EDA.Producer.Demo.Domain.Common.Interfaces;

namespace EDA.Producer.Demo.Domain.CheckGeneration.Events;

public record CheckGenerationRequested(Guid Id): IDomainEvent;