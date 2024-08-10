using DomainDrivenDesignEShop.Domain.Customers;
using DomainDrivenDesignEShop.Domain.Products;

namespace DomainDrivenDesignEShop.Domain.Orders;

public class Order
{
    private Order()
    {
        
    }
    private readonly HashSet<LineItem> _lineItems = new();
    public OrderId Id { get; private set; }
    public CustomerId CustomerId { get; private set; }

    public IReadOnlyList<LineItem> LineItems => _lineItems.ToList();

    public static Order Create(CustomerId customerId)
    {
        var order = new Order
        {
            Id = new OrderId(Guid.NewGuid()),
            CustomerId = customerId
        };
        return order;
    }
    public void Add(ProductId productId, Money productPrice)
    {
        var lineItem = new LineItem(new LineItemId(Guid.NewGuid()), Id, productId, productPrice);

        _lineItems.Add(lineItem);
    }

    public void RemoveLineItem(LineItemId lineItemId)
    {
        var lineItem = _lineItems.FirstOrDefault(o => o.Id == lineItemId);
        if (lineItem is null)
        {
            return;
        }

        _lineItems.Remove(lineItem);
    }
}