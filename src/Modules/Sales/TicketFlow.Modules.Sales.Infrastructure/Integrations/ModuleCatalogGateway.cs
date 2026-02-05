using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketFlow.Modules.Catalog.Application.UseCases.Events;
using TicketFlow.Modules.Sales.Application.Integrations;

namespace TicketFlow.Modules.Sales.Infrastructure.Integrations;

public class ModuleCatalogGateway : ICatalogGateway
{
    private readonly GetByIdUseCase _getByIdUseCase;

    public ModuleCatalogGateway(GetByIdUseCase getByIdUseCase)
    {
        _getByIdUseCase = getByIdUseCase;
    }

    public async Task<decimal?> GetEventPriceAsync(Guid eventId)
    {
        var eventDto = await _getByIdUseCase.ExecuteAsync(eventId);
        if (eventDto is null)
            return null;

        //TODO adicionar price em Event
        return 100.00m;
    }
}
