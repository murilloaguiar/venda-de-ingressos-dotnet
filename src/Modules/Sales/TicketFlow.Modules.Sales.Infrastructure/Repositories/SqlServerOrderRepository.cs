using Microsoft.EntityFrameworkCore;
using TicketFlow.Modules.Sales.Domain.Entities;
using TicketFlow.Modules.Sales.Domain.Repositories;
using TicketFlow.Modules.Sales.Infrastructure.Database;

namespace TicketFlow.Modules.Sales.Infrastructure.Repositories;

public class SqlServerOrderRepository : IOrderRepository
{
    private readonly SalesDbContext _context;

    public SqlServerOrderRepository(SalesDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddRangeAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await _context.Orders.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task UpdateAsync(Order order)
    {
        _context.Update(order);
        await _context.SaveChangesAsync();
    }
}
