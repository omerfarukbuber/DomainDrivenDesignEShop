using DomainDrivenDesignEShop.Application.Data;
using DomainDrivenDesignEShop.Domain.Customers;
using DomainDrivenDesignEShop.Domain.Orders;
using MediatR;

namespace DomainDrivenDesignEShop.Application.Orders.Create;

internal sealed class CreateOrderCommandHandler(IAppDbContext context, IPublisher publisher) : IRequestHandler<CreateOrderCommand>
{
    private readonly IAppDbContext _context = context;
    private readonly IPublisher _publisher = publisher;

    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var customer = await _context.Customers.FindAsync(request.CustomerId, cancellationToken);

        if (customer is null)
        {
            return;
        }

        var order = Order.Create(customer.Id);

        await _context.Orders.AddAsync(order, cancellationToken);

        await _context.OrderSummaries.AddAsync(new OrderSummary(order.Id.Value, order.CustomerId.Value, 0), cancellationToken);


        await _context.SaveChangesAsync(cancellationToken);

        await _publisher.Publish(new OrderCreatedEvent(order.Id), cancellationToken);
    }
}