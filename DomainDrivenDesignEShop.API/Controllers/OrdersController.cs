using DomainDrivenDesignEShop.Application.Orders.Create;
using DomainDrivenDesignEShop.Application.Orders.GerOrderSummary;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesignEShop.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class OrdersController(ISender sender) : Controller
{

    private readonly ISender _sender = sender;

    [HttpGet("{id:guid}/Summary")]
    public async Task<IActionResult> GetOrderSummaryAsync([FromRoute] Guid id)
    {
        var query = new GetOrderSummaryQuery(id);
        return Ok(await _sender.Send(query));
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderAsync(CreateOrderCommand createOrderCommand)
    {
        await _sender.Send(createOrderCommand);

        return Ok();
    }
    
}