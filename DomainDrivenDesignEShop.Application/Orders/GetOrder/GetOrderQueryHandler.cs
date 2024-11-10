using DomainDrivenDesignEShop.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesignEShop.Application.Orders.GetOrder;

public class GetOrderQueryHandler(IAppDbContext context) : IRequestHandler<GetOrderQuery, OrderResponse?>
{
    private readonly IAppDbContext _context = context;

    public async Task<OrderResponse?> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        //With EF CORE Linq

        //var order = await _context.Orders
        //    .Include(o => o.LineItems)
        //    .SingleOrDefaultAsync(o => o.Id == request.OrderId, cancellationToken: cancellationToken);

        //var orderResponse = new OrderResponse(order.Id.Value,
        //    order.CustomerId.Value,
        //    order.LineItems.Select(li => new LineItemResponse(li.Id.Value,
        //        li.Price.Amount)).ToList()
        //    );


        //With EF CORE Raw Sql

        var orderSummaries = await _context.Database.SqlQuery<OrderSummary>(@$"
            SELECT o.Id as OrderId, o.CustomerId, li.Id as LineItemId, li.Price_Amount as LineItemPrice
            FROM Orders as o
            JOIN LineItems as li ON o.Id = li.OrderId
            WHERE o.Id = {request.OrderId.Value}").ToListAsync(cancellationToken);

        var orderResponse = orderSummaries
            .GroupBy(o => o.OrderId)
            .Select(grp => new OrderResponse(
                grp.Key,
                grp.First().CustomerId,
                grp.Select(o => new LineItemResponse(o.LineItemId, o.LineItemPrice)).ToList()))
            .Single();

        return orderResponse;
    }

    private sealed record OrderSummary(Guid OrderId, Guid CustomerId, Guid LineItemId, decimal LineItemPrice);
}