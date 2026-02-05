using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketFlow.Modules.Sales.Application.Integrations;

public interface ICatalogGateway
{
    Task<decimal?> GetEventPriceAsync(Guid eventId);
}
