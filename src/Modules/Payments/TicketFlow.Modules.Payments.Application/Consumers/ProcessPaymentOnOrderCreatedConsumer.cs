using MassTransit;
using Microsoft.Extensions.Logging;
using TicketFlow.Shared.Kernel.Integrations;

namespace TicketFlow.Modules.Payments.Application.Consumers;

public class ProcessPaymentOnOrderCreatedConsumer : IConsumer<IOrderCreatedIntegrationEvent>
{
    private ILogger<ProcessPaymentOnOrderCreatedConsumer> _logger;

    public ProcessPaymentOnOrderCreatedConsumer(ILogger<ProcessPaymentOnOrderCreatedConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<IOrderCreatedIntegrationEvent> context)
    {
        var message = context.Message;

        _logger.LogInformation("[PAGAMENTOS] A contatar a operadora do cartão de crédito...");

        await Task.Delay(2000);

        var paymentId = Guid.NewGuid();
        _logger.LogInformation($"[PAGAMENTOS] Pagamento {paymentId} aprovado para o pedido {message.OrderId}...");

        await context.Publish<IPaymentApprovedIntegrationEvent>(new 
        {
            OrderId = message.OrderId,
            PaymentId = paymentId,
            OccurredOn = DateTime.UtcNow,
        });

    }
}
