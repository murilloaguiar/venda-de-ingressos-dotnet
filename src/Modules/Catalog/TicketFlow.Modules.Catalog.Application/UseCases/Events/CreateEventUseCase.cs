using TicketFlow.Modules.Catalog.Domain.Entities;
using TicketFlow.Modules.Catalog.Domain.Repositories;

namespace TicketFlow.Modules.Catalog.Application.UseCases.Events;
public class CreateEventUseCase
{
    private readonly IEventRepository _eventRepository;

    public CreateEventUseCase(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<Guid> ExecuteAsync(CreateEventRequest request)
    {
        var ticketEvent = Event.Create(request.Title, request.Description, request.Date);

        await _eventRepository.AddAsync(ticketEvent);

        return ticketEvent.Id;

    }
}
