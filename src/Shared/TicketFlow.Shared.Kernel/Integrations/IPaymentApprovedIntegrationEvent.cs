namespace TicketFlow.Shared.Kernel.Integrations;

public interface IPaymentApprovedIntegrationEvent
{
    Guid OrderId { get; }
    Guid PaymentId { get; }
    DateTime EventOccurredOn { get; }
}
