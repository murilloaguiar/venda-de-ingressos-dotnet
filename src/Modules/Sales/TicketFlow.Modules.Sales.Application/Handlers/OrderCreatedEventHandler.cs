using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using TicketFlow.Modules.Sales.Domain.Events;
using TicketFlow.Shared.Kernel.Integrations;

namespace TicketFlow.Modules.Sales.Application.Handlers;

public class OrderCreatedEventHandler : INotificationHandler<OrderCreatedEvent>
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<OrderCreatedEventHandler> _logger;

    public OrderCreatedEventHandler(IPublishEndpoint publishEndpoint, ILogger<OrderCreatedEventHandler> logger)
    {
        _publishEndpoint = publishEndpoint;
        _logger = logger;
    }

    public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"[BRIGDE] Recebendo evento de dominio {notification.OrderId}. Publicando no RabbitMq...");

        await _publishEndpoint.Publish<IOrderCreatedIntegrationEvent>(new
        {
            OrderId = notification.OrderId,
            CustomerId = notification.CustomerId,
            OccurredOn = notification.OccurredOn,
        }, cancellationToken);

        _logger.LogInformation("[BRIGDE] Mensagem enviada para o RabbitMq.");
    }
}
