namespace TicketFlow.Shared.Kernel.Integrations;

public class IPaymentApprovedIntegrationEvent
{
    Guid OrderId { get; }
    Guid PaymentId { get; }
    DateTime EventOccurredOn { get; }
}
