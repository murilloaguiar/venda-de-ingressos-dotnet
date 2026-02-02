using TicketFlow.Modules.Catalog.Domain.Entities;
using TicketFlow.Modules.Catalog.Domain.Repositories;
using TicketFlow.Modules.Catalog.Infrastructure.Database;

namespace TicketFlow.Modules.Catalog.Infrastructure.Repositories;
public class SqlServerEventRepository : IEventRepository
{
    private readonly CatalogDbContext _context;

    public SqlServerEventRepository(CatalogDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Event ticketEvent)
    {
        await _context.Events.AddAsync(ticketEvent);
        await _context.SaveChangesAsync();
    }
}
