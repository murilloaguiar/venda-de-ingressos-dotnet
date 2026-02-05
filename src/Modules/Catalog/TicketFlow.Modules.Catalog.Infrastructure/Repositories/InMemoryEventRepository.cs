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

    public Task<Event?> GetByIdAsync(Guid id)
    {
        var ticketEvent = _events.Find(e => e.Id == id);

        return Task.FromResult(ticketEvent);
    }
}
