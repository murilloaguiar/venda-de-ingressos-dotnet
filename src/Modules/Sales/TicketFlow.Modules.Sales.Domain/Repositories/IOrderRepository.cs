using TicketFlow.Modules.Sales.Domain.Entities;

namespace TicketFlow.Modules.Sales.Domain.Repositories;

public interface IOrderRepository
{
    Task AddAsync(Order order);
}
