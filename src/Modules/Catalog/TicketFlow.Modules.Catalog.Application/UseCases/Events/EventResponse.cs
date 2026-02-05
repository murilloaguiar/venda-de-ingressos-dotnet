namespace TicketFlow.Modules.Catalog.Application.UseCases.Events;

public record EventResponse(Guid Id, string Title, string Description, DateTime Date)
{
}
