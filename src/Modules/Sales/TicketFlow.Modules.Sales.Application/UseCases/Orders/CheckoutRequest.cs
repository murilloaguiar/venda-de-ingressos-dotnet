namespace TicketFlow.Modules.Sales.Application.UseCases.Orders;
public record CheckoutItem(Guid EventId, int Quantity);
public record CheckoutRequest(Guid CustomerId, List<CheckoutItem> Items);
