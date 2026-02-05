using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
}
