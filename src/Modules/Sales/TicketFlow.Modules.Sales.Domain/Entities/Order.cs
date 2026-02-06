using TicketFlow.Modules.Sales.Domain.Events;
using TicketFlow.Shared.Kernel.Abstractions;

namespace TicketFlow.Modules.Sales.Domain.Entities;

public class Order : Entity, IAggregateRoot
{
    public Guid CustomerId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private readonly List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
    public decimal TotalAmount => _items.Sum(i => i.TotalPrice);

    public enum OrderStatus { Pending, Paid, Cancelled }
    public OrderStatus Status { get; private set; }

    private Order(){}

    private Order(Guid customerId)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        CreatedAt = DateTime.UtcNow;
        Status = OrderStatus.Pending;

        AddDomainEvent(new OrderCreatedEvent(Id, CustomerId, DateTime.UtcNow));
    }

    public static Order Create(Guid customerId)
    {
        if(customerId ==  Guid.Empty)
            throw new ArgumentException("Cliente Inválido.",nameof(customerId));

        return new Order(customerId);
    }

    public void AddItem(Guid eventId, int quantity, decimal unitPrice)
    {
        var item = new OrderItem(eventId, quantity, unitPrice);
        _items.Add(item);
    }
}
