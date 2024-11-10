using DomainDrivenDesignEShop.Application.Data;
using DomainDrivenDesignEShop.Domain.Orders;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesignEShop.Application.Orders.GerOrderSummary;

internal sealed class GetOrderSummaryQueryHandler(IAppDbContext context)
    : IRequestHandler<GetOrderSummaryQuery, OrderSummary?>
{
    private readonly IAppDbContext _context = context;

    public async Task<OrderSummary?> Handle(GetOrderSummaryQuery request, CancellationToken cancellationToken)
    {
        return await _context.OrderSummaries
            .AsNoTracking().
            FirstOrDefaultAsync(o => o.Id == request.OrderId, cancellationToken);

    }
}