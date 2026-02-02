using TicketFlow.Modules.Catalog.Domain.Entities;
using TicketFlow.Modules.Catalog.Domain.Repositories;

namespace TicketFlow.Modules.Catalog.Infrastructure.Repositories;
public class InMemoryEventRepository : IEventRepository
{
    private readonly List<Event> _events = new();
    public Task AddAsync(Event ticketEvent)
    {
        _events.Add(ticketEvent);
        return Task.CompletedTask;
    }
}
