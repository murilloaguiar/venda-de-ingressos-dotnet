namespace TicketFlow.Modules.Catalog.Application.UseCases.Events;

public record CreateEventRequest(string Title, string Description, DateTime Date);
