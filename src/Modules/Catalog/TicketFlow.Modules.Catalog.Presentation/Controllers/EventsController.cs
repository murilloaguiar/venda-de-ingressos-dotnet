using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketFlow.Modules.Catalog.Application.UseCases.Events;

namespace TicketFlow.Modules.Catalog.Presentation.Controllers;

[ApiController]
[Route("api/events")]
public class EventsController(CreateEventUseCase _createEventUseCase): ControllerBase
{

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
}
