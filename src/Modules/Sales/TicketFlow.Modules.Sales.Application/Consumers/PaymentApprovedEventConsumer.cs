using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketFlow.Modules.Sales.Domain.Repositories;
using TicketFlow.Shared.Kernel.Integrations;

namespace TicketFlow.Modules.Sales.Application.Consumers;
public class PaymentApprovedEventConsumer : IConsumer<IPaymentApprovedIntegrationEvent>
{
    private readonly IOrderRepository _orderRepository;
    private readonly ILogger<PaymentApprovedEventConsumer> _logger;

    public PaymentApprovedEventConsumer(IOrderRepository orderRepository, ILogger<PaymentApprovedEventConsumer> logger)
    {
        _orderRepository = orderRepository;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<IPaymentApprovedIntegrationEvent> context)
    {
        var message = context.Message;
        _logger.LogInformation($"[VENDAS] Recebido aviso de pagamento aprovado para o pedido: {message.OrderId}");

        var order = await _orderRepository.GetByIdAsync(message.OrderId);

        if (order == null)
        {
            _logger.LogError($"[VENDAS] Pedido {message.OrderId} não existe!");
            return;
        }

        order.MarkAsPaid();

        await _orderRepository.UpdateAsync(order);

        _logger.LogInformation($"[VENDAS] Status do Pedido {order.Id} alterado para pago com sucesso");
    }
}
