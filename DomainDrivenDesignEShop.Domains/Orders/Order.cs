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
}