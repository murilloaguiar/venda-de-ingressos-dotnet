using TicketFlow.Shared.Kernel.Events;

namespace TicketFlow.Modules.Sales.Domain.Events;

public record OrderCreatedEvent(Guid OrderId, Guid CustomerId, DateTime OccurredOn) : IDomainEvent
{

}
