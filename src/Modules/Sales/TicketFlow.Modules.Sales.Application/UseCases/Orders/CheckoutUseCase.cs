using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketFlow.Modules.Sales.Application.Integrations;
using TicketFlow.Modules.Sales.Domain.Entities;
using TicketFlow.Modules.Sales.Domain.Repositories;

namespace TicketFlow.Modules.Sales.Application.UseCases.Orders;

public class CheckoutUseCase
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICatalogGateway _catalogGateway;

    public CheckoutUseCase(IOrderRepository orderRepository, ICatalogGateway catalogGateway)
    {
        _orderRepository = orderRepository;
        _catalogGateway = catalogGateway;
    }

    public async Task<Guid> ExecuteAsync(CheckoutRequest request)
    {
        var order = Order.Create(request.CustomerId);

        foreach (var item in request.Items)
        {
            var price = await _catalogGateway.GetEventPriceAsync(item.EventId);
            if (price is null)
                throw new ArgumentException($"O evento {item.EventId} não existe ou não está disponível.");

            order.AddItem(item.EventId, item.Quantity, price.Value);

        }

        await _orderRepository.AddAsync(order);
        return order.Id;
    }
}
