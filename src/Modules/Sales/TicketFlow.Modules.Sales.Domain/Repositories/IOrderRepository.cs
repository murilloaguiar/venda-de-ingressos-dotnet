using TicketFlow.Modules.Sales.Domain.Entities;

namespace TicketFlow.Modules.Sales.Domain.Repositories;

public interface IOrderRepository
{
    Task AddAsync(Order order);
    Task<Order?> GetByIdAsync(Guid id);
    Task UpdateAsync(Order order);
}
