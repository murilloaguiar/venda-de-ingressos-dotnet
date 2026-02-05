using Microsoft.AspNetCore.Mvc;
using TicketFlow.Modules.Catalog.Application.UseCases.Events;

namespace TicketFlow.Modules.Catalog.Presentation.Controllers;

[ApiController]
[Route("api/events")]
public class EventsController(
    CreateEventUseCase createEventUseCase,
    GetByIdUseCase getByIdUseCase): ControllerBase
{
    private readonly CreateEventUseCase _createEventUseCase = createEventUseCase;
    private readonly GetByIdUseCase _getByIdUseCase = getByIdUseCase;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEventRequest request)
    {
        try
        {
            var eventId = await _createEventUseCase.ExecuteAsync(request);
            return CreatedAtAction(nameof(Create), new {id = eventId});
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var ticketEvent = await _getByIdUseCase.ExecuteAsync(id);
        if(ticketEvent is null)
            return NotFound();

        return Ok(ticketEvent);
    }
}
