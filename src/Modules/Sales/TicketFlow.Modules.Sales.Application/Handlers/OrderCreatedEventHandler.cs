using MediatR;
using TicketFlow.Modules.Sales.Domain.Events;

namespace TicketFlow.Modules.Sales.Application.Handlers;

public class OrderCreatedEventHandler : INotificationHandler<OrderCreatedEvent>
{
    public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
