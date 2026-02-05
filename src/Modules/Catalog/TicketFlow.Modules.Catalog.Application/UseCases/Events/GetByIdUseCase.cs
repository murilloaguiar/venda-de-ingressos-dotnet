using TicketFlow.Modules.Catalog.Domain.Repositories;

namespace TicketFlow.Modules.Catalog.Application.UseCases.Events;

public class GetByIdUseCase
{
    private readonly IEventRepository _repository;

    public GetByIdUseCase(IEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<EventResponse?> ExecuteAsync(Guid id)
    {
        var ticketEvent = await _repository.GetByIdAsync(id);

        if (ticketEvent is null)
            return null;

        return new EventResponse(
            ticketEvent.Id,
            ticketEvent.Title,
            ticketEvent.Description,
            ticketEvent.Date);
    }
}
