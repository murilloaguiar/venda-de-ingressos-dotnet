using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketFlow.Shared.Kernel.Integrations;
public interface IOrderCreatedIntegrationEvent
{
    Guid OrderId { get; }
    Guid CustomerId { get; }
    DateTime OccuredOn { get; }

}
