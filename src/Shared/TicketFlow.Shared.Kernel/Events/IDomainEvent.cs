using MediatR;

namespace TicketFlow.Shared.Kernel.Events;

public interface IDomainEvent : INotification
{
    DateTime OccurredOn { get; }
}
