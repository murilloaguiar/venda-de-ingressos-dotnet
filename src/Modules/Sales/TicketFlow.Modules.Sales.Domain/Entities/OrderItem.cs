using TicketFlow.Shared.Kernel.Abstractions;

namespace TicketFlow.Modules.Sales.Domain.Entities;

public class OrderItem : Entity
{
    public Guid EventId { get; private set; }
    public int Quantity{ get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal TotalPrice => Quantity * UnitPrice;

    private OrderItem() { }

    public OrderItem(Guid eventId, int quantity, decimal unitPrice)
    {
        if (quantity < 0)
            throw new ArgumentException("Quantidade deve ser maior que zero.", nameof(quantity));
        
        Id = Guid.NewGuid();
        EventId = eventId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}
