using DomainDrivenDesignEShop.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesignEShop.Application.Orders.RemoveLineItem;

internal sealed class RemoveLineItemCommandHandler(IAppDbContext context) : IRequestHandler<RemoveLineItemCommand>
{
    private readonly IAppDbContext _context = context;

    public async Task Handle(RemoveLineItemCommand request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders
            .Include(o => o.LineItems.Where(li => li.Id == request.LineItemId))
            .SingleOrDefaultAsync(o => o.Id == request.OrderId, cancellationToken: cancellationToken);

        order?.RemoveLineItem(request.LineItemId);

        await _context.SaveChangesAsync(cancellationToken);
    }
}