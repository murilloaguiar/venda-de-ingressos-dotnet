using MassTransit;
using Microsoft.Extensions.Logging;
using TicketFlow.Shared.Kernel.Integrations;

namespace TicketFlow.Modules.Notifications.Application.Consumers;

public class OrderCreatedEventConsumer : IConsumer<IOrderCreatedIntegrationEvent>
{
    private readonly ILogger<OrderCreatedEventConsumer> _logger;

    public OrderCreatedEventConsumer(ILogger<OrderCreatedEventConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<IOrderCreatedIntegrationEvent> context)
    {
        var message = context.Message;
        _logger.LogWarning($"[MODULO DE NOTIFICACOES] Lendo mensagem do RabbitMQ");
        _logger.LogWarning($"Preparando envio de e-mail para o Cliente: {message.CustomerId}");
        _logger.LogWarning($"Com os ingressos do pedido: {message.OrderId}");
        _logger.LogWarning($"Email enviado com sucesso.");
        
        return Task.CompletedTask;
    }
}
