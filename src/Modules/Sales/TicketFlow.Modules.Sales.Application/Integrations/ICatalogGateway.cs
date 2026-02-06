namespace TicketFlow.Modules.Sales.Application.Integrations;

public interface ICatalogGateway
{
    Task<decimal?> GetEventPriceAsync(Guid eventId);
}
