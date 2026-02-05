using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketFlow.Modules.Sales.Application.UseCases.Orders;
public record CheckoutItem(Guid EventId, int Quantity);
public record CheckoutRequest(Guid CustomerId, List<CheckoutItem> Items);
