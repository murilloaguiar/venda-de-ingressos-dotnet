using TicketFlow.Modules.Catalog.Domain.Entities;

namespace TicketFlow.Modules.Catalog.Domain.Repositories;
public interface IEventRepository
{
    Task AddAsync(Event ticketEvent);
    Task<Event?> GetByIdAsync(Guid id);
}
