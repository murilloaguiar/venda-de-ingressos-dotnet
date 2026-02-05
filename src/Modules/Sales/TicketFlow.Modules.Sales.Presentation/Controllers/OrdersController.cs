using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketFlow.Modules.Sales.Application.UseCases.Orders;

namespace TicketFlow.Modules.Sales.Presentation.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController(CheckoutUseCase checkoutUseCase) : ControllerBase
{
    private readonly CheckoutUseCase _checkoutUseCase = checkoutUseCase;

    [HttpPost]
    public async Task<IActionResult> Checkout([FromBody] CheckoutRequest request)
    {
        try
        {
            var orderId = await _checkoutUseCase.ExecuteAsync(request);
            return Ok(new { OrderId = orderId });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });

        }

    }
}
